using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace myfirstrazorpages.Pages
{
    //From version 2.1 of ASP.NET Core, you can add the new [BindProperties] attribute 
    //to the PageModel class rather than applying [BindPRoperty] to individual properties, 
    //which results in all the public properties in the PageModel taking part in model binding。
    
    //or decorated with the BindProperty attribute in each property whitch you want
    [BindProperties]
    public class WithPageModelApproachPageModel : PageModel
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }
}