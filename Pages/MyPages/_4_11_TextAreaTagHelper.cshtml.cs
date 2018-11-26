using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class TextAreaTagHelperModel : PageModel
{
    [BindProperty, MaxLength(20)]
    public string Memo { get; set; }
    [TempData]
    public string Msg { get; set; }

    public RedirectToPageResult OnPostSave()
    {
        Msg = $"TA value is {Memo}";
        return RedirectToPage();
    }
}