using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ViewComponentsPageModel : PageModel
{
    [TempData]
    public string Message { get; set; }
    public string itemId { get; set; }
    
    [BindProperty]
    public string SelectSampleId { get; set; }
    public void OnGet()
    {
        itemId = "1201";
    }
    public void OnPostSave()
    {
        // Message = Request.Form["SelectSampleId"];
        Message = SelectSampleId;
    }
}