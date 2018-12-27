using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CustomPageRouteConvModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string Handler { get; set; }

    public void OnGet()
    {
        // the Title property is automatically bound
    }

}