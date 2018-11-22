using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

public class SelectTagHelperModel : PageModel
{
    public string Msg { get; set; }

    [Display(Name = "项目")]
    public List<SelectListItem> Items { get; set; }

    [Display(Name = "样品")]
    public IEnumerable<object> Samples { get; set; }

    [BindProperty]
    public string SelItemVal { set; get; }

    [BindProperty]
    public string SelSampleVal { set; get; }

    public void OnGet()
    {
        // read msg from last action 
        // if (TempData.Keys.Contains("msg"))
        //     Msg = TempData["msg"].ToString();

        // get data from routedata, because of the page route templet “"{handler?}/{sta?}"”
        if (RouteData.Values.Keys.Contains("sta"))
            Msg += RouteData.Values.Single(x => x.Key.ToString() == "sta").Value.ToString();

        // get data from querystring，for that fukin not adapte the page route templet
        if (Request.Query.Keys.Contains("fukin"))
            Msg += Request.Query.Single(x => x.Key.ToString() == "fukin").Value.ToString();

        // source_items from db
        Dictionary<string, string> source_items = new Dictionary<string, string>
        {
            {"1101", "fukin"},
            {"1102", "fukin2"},
            {"1103", "fukin3"}
        };

        Dictionary<string, string> source_samples = new Dictionary<string, string>
        {
            {"110101", "chd1"},
            {"110102", "chd2"},
            {"110301", "chd3"}
        };

        // use SelectListItem for select tag
        Items = source_items.Select(x => new SelectListItem
        {
            Value = x.Key,
            Text = x.Value
        }).ToList();

        // use SelectList for select tag
        Samples = source_samples.Select(x => new { SampleId = x.Key, SampleName = x.Value });
    }

    public void OnGetTestTempData()
    {
        Samples = (new int[]{1}).Select(x => new { SampleId = -1, SampleName = "abc" });

        // after using TempData, it will be release
        Msg += $"reload TempData then, its null ? \"{ TempData["msg"] }\"";
    }

    public RedirectToPageResult OnPostShowSelItem()
    {
        // save msg to TempData
        TempData["msg"] = "OnPostShowSelItem() did! ";

        // "a" is a handler , not exist here
        return RedirectToPage("_4_9_SelectTagHelper", "a",
        new { sta = $"{SelItemVal}", fukin = $"{SelSampleVal}" });
    }
}