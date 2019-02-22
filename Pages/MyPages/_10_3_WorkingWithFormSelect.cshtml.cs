using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfirstrazorpages;

public class WorkingWithFormSelectModel : PageModel
{
    [TempData]
    public string Message { get; set; }
        
    [BindProperty]
    public string SelectedKind { get; set; }

    public SelectList OptionsKind { get; set; }

    public void OnGet()
    {
        // simulator data
        List<Kind> sourceKindList = new List<Kind>();
        sourceKindList.Add(new Kind { KindId = "11", KindName = "结构材料" });
        sourceKindList.Add(new Kind { KindId = "12", KindName = "市政道路" });
        sourceKindList.Add(new Kind { KindId = "13", KindName = "节能材料" });
        sourceKindList.Add(new Kind { KindId = "14", KindName = "装饰装修材料" });

        // use SelectList to create the options
        OptionsKind = new SelectList(sourceKindList.ToList(), nameof(Kind.KindId), nameof(Kind.KindName));

        // set default(or saved) select item, should from db
        SelectedKind = "13";
    }

    public RedirectToPageResult OnPostSave()
    {
        Message = SelectedKind;
        return RedirectToPage();
    }
}
