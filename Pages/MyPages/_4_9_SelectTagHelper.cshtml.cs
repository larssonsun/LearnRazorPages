using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

public class SelectTagHelperModel : PageModel
{
    public string Msg { get; set; }
    public List<SelectListItem> Items { get; set; }
    
    [BindProperty]
    public string SelItemVal { set; get; }
    public void OnGet()
    {
        // source_items from db
        Dictionary<string, string> source_items = new Dictionary<string, string>
        {
            {"1101", "fukin"},
            {"1102", "fukin2"},
            {"1103", "fukin3"}
        };

        Items = source_items.Select(x => new SelectListItem
        {
            Value = x.Key,
            Text = x.Value
        }).ToList();
    }

    public void OnPostShowSelItem()
    {
        Msg = $"{SelItemVal}";
        // return RedirectToPage("_4_9_SelectTagHelper");
    }
}