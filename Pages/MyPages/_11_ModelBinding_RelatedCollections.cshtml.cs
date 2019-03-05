using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfirstrazorpages;

public class RelatedCollectionsPageModel : PageModel
{
    [TempData]
    public string Message { get; set; }

    [BindProperty]
    public Kind SelectedKind { get; set; }
    public List<Kind> kinds { get; set; }

    [BindProperty]
    public string FilterStgr { get; set; }
    public void OnGet()
    {
        DataInit(null);
    }

    public void OnPostFilter()
    {
        DataInit(FilterStgr);
    }

    private void DataInit(string kindid)
    {
        List<Item> items = new List<Item>();
        items.Add(new Item { ItemName = "水泥", ItemId = "1101" });
        items.Add(new Item { ItemName = "粗骨料", ItemId = "1102" });
        items.Add(new Item { ItemName = "细骨料", ItemId = "1103" });
        items.Add(new Item { ItemName = "墙体材料", ItemId = "1104" });


        kinds = new List<Kind>();
        kinds.Add(new Kind
        {
            KindName = "结构材料",
            KindId = "11",
            SelItems = new SelectList(items, nameof(Item.ItemId), nameof(Item.ItemName))
        });
        kinds.Add(new Kind { KindName = "市政道路", KindId = "12", SelItems = new SelectList(new List<Item>()) });
        kinds.Add(new Kind { KindName = "节能材料", KindId = "13", SelItems = new SelectList(new List<Item>()) });

        if (kindid != null)
            kinds = kinds.Where(x=>x.KindId==kindid).ToList();

    }
}
