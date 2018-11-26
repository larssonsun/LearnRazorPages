using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ValidateTagHelperModel : PageModel
{
    [BindProperty]
    public Player Player { get; set; }

    [TempData]
    public string Msg { get; set; }

    public RedirectToPageResult OnPostSave()
    {
        Msg = $"playname is {Player.PlayerName} (ModelState.IsValid: {ModelState.IsValid}).";
        return RedirectToPage();
    }
}

public class Player
{
    [Required, MaxLength(5, ErrorMessage="球员名称的长度必须小于5"), Display(Name="球员名称")]
    public string PlayerName { get; set; }
}