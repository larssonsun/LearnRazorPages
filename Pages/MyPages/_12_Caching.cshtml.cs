using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using myfirstrazorpages;

public class CachingPageModel : PageModel
{
    private readonly IMemoryCache _cache;

    // It is enabled when it is added as a service in the ConfigureServices method 
    // in the Startup class using the AddMemoryCache extension method
    public CachingPageModel(IMemoryCache cache)
    {
        _cache = cache;
    }

    [BindProperty]
    public Item Item { get; set; }

    [BindProperty]
    public string KindId { get; set; }

    public void OnGet()
    {
        KindId = "11";

        Item cItem = null;
        if (!_cache.TryGetValue("item", out cItem))
            Item = new Item { ItemName = "水泥", ItemId = "1101" };
        else
            Item = cItem;
    }

    public RedirectToPageResult OnPostSetItem()
    {
        var itemCache = _cache.GetOrCreate("item", entity =>
        {
            // The cache will expire aflter the time 
            // entity.AbsoluteExpiration=DateTime.Parse("2019-02-27 12:55");

            // The cache will expire in 1 minute
            // entity.AbsoluteExpirationRelativeToNow = new TimeSpan(0,1,0);

            // The cache will expire after 5 seconds from last request
            // entity.SlidingExpiration = new TimeSpan(0, 0, 5);

            // 这里我自定义了一个对象返回一个IChangeToken对象，用处是将submit 的KindId与预设的“12”进行比较
            // 如果相互不等于则cache直接过期（等于没缓存）。
            // 实际应用中这个“12”应该是从数据库或者其他缓存中得到（在IfKindChanged中实现）
            var en = entity as Item;
            IfKindChanged ikc = new IfKindChanged(KindId, "12");
            entity.ExpirationTokens.Add(ikc.Watch());

            return new Item { ItemName = "细骨料", ItemId = "1102" };
        });

        // if (itemCache != null)
        //     Console.WriteLine(itemCache.ItemName);

        return RedirectToPage();
    }

    public RedirectToPageResult OnPostRemoveItem()
    {
        _cache.Remove("item");
        return RedirectToPage();
    }
}