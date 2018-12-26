
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class AreasPageModel : PageModel
{
    public RedirectToPageResult OnGetGotoAreaAdminFuckinUsers()
    {
        return RedirectToPage(pageName: "/FukinUsers", routeValues: new { area = "Admin" });
    }
}