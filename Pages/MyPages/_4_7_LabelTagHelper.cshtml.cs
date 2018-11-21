using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class Usr
{
    [Display(Name = "用户名")]
    [Required]
    public string UserName { get; set; }

    [DataType(DataType.Password)]
    [Required]
    public string Password { set; get; }
}

public class LabelTagHelperModel : PageModel
{
    [BindProperty]
    public Usr Usr { get; set; }
    public string Msg { get; set; }
}