using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ViewDataInRazorPages : PageModel
{
    public string MainMsg = null;

    [ViewData]
    public string MsgForPartial_Part2_ByViewDataAttr { get; set; }
    /*The ViewData attribute was introduced in ASP.NET Core 2.1. 
    PageModel properties decorated with this attribute are automatically added 
    as keys to the ViewData dictionary along with any value that has been assigned to them. */

    public void OnGet()
    {
        MainMsg = "MainMsg in Main Page";
        /* You should prefer to access properties of the Model in a content page 
        because you benefit from strong typing: IntelliSense and compile-time checking. 
        So why should you use the ViewData attribute on model properties? 
        The real benefit of this feature comes when working with layout pages. 
        ViewData is shared with the layout page (and any partial pages called by the content page or the layout), 
        so the attribute makes it easy to pass typed data from the PageModel to the layout page or 
        partials without having to explicitly assign it to the ViewData dictionary. */
        ViewData["MsgForPartial"] = @"Partial Msg For PartialPage
             from Main Page in ViewData";
        MsgForPartial_Part2_ByViewDataAttr = "MsgForPartial_Part2_ByViewDataAttr";
    }
}