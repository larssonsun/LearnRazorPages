using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;

public class PlayerVM
{
    public string PlayerNo { get; set; }
    public string PlayerName { get; set; }
    public string PlayerAge { get; set; }

    public string PlayInfo { get; set; }
}

public class NamedHandlerMethodsModel : PageModel
{
    public string Message { get; set; }
    public List<PlayerVM> Players = null;
    public void OnPostDelPlayer()
    {
        Message = "Post Delplayer, not redirect to any page";
        //void in the function will do return new PageResult() or return Page()
    }

    public IActionResult OnPostAddPlayer()
    {
        // this following code of prop Message set will not show on the page, 
        //because it will redirect to new page
        Message = "Post Addplayer, redirect to page _3_2_NamedHanderMethods";
        //the function RedirectToPage() is the same as new RedirectToPageResult()
        return RedirectToPage("_3_2_NamedHanderMethods");
    }

    public PageResult OnPostEditPlayer()
    {
        //Generally, it is a good idea to be as specific as possible with handler method return types
        //so use PageResult replace the interface IActionResult for PageResult

        Message = "Post Editplayer, not redirect to any page";
        return Page();
    }

    public void OnGet()
    {
        //simulate data
        var playerModel = (new int[1]).Select(x => new { id = "001", name = "larsson", age = 37 });

        Players = playerModel.Select(x => new PlayerVM()
        {
            PlayerNo = x.id,
            PlayInfo = $"{x.name}({x.age.ToString()})"
        }).ToList();
    }

}
