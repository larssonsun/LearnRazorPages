using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ValidateTagHelper2Model : PageModel
{
    [BindProperty]
    public Man Man { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "请输入类型。")]
    [MaxLength(10, ErrorMessage = "类型必须小于2位。")]
    public string Type { get; set; 
    }
    [TempData]
    public string Msg { set; get; }

    public PageResult OnPostSave()
    {
        Msg = $"ModelState.IsValid: {ModelState.IsValid}";
        return Page();
    }
}

public class Man
{
    [Required(ErrorMessage = "请输入姓氏。")]
    [MinLength(10, ErrorMessage = "姓氏必须大于10位。")]
    public string FirstName { get; set; }
}