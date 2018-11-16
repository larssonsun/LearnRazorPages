using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class UseActionResult : PageModel
{
    public string Message { get; set; }

    [BindProperty]
    public string PlayerName { get; set; }

    public IActionResult OnPostSave()
    {
        Message = "IActionResult OnPostSave() occured";
        // var name = Request.Form["playername"].ToString();
        if (PlayerName == "henrik")
        {
            // PlayerName = Request.Form["playername"].ToString();
            Message = $"IActionResult OnPostSave() occured return Page()";
            return Page();
        }
        else
        {
            // set the page StatusCode 302 and redirect to page "_1_1_Use"
            return RedirectToPage("_1_1_Use");
        }
    }

    public void OnGet()
    {
        PlayerName = "larsson";
        Message = "OnGet() occured";
    }
}