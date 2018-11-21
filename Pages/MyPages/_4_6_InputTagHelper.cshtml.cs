using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class Member
{
    public int PersonId { get; set; }
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string Telephone { get; set; }
    [Display(Name = "出生年月")]
    public DateTime DateOfBirth { get; set; }
    public decimal Salary { get; set; }
    [Url]
    public string Website { get; set; }
    [Display(Name = "Send spam to me")]
    public bool SendSpam { get; set; }
    public int? NumberOfCats { get; set; }
    public IFormFile Selfies { get; set; }
}
public class InputTagHelperModel : PageModel
{
    [BindProperty]
    public Member Member { get; set; }
    public string Msg { get; set; }
    public void OnGet()
    {
    }

    public void OnPostSave()
    {
        Msg = "saved!";
    }
}