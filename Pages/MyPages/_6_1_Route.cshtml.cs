using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


public class RoutePageModel : PageModel
{
    public static class N
    {
        public static string Name { get; set; }
        public static string Submit { get; set; }
        public static string FirstName { get; set; }
    }

    [TempData]
    public string Msg { set; get; }

    public string Msg2 { set; get; }

    // 非绑定的PageModel属性
    public string Name { set; get; }

    // 绑定的PageModel属性
    [BindProperty]
    public string FirstName { set; get; }

    [BindProperty(SupportsGet=true)]
    public string Shity { set; get; }

    public void OnGet()
    {
        N.Name = "名";
        N.FirstName = "姓";
        N.Submit = "提交保存";
        if (RouteData.Values.ContainsKey("handler"))
            Msg = $"RouteData.Values[\"handler\"] = { RouteData.Values["handler"] }";

        // because of the "[BindProperty(SupportsGet=true)]" for prop "Shity", it will be:
        // public void OnGet(string shity)
        // {
        //     Shity = shity;
        // }
        Msg2 = $"RouteData.Values[\"shity\"] = { Shity }";
    }
    public RedirectToPageResult OnPostSave()
    {
        //no value is here from "Name"
        Console.WriteLine($"Name={Name}");

        // because of BindProperty , the Prop FirstName will be doing like the following :
        // FirstName = Request.Form["FirstName"].ToString();
        Console.WriteLine($"FirstName={FirstName}");

        Msg = $"name from form = {Request.Form["name"].ToString()}";
        Msg2 = $"first name from = {FirstName}";

        // the prop "FirstName" will set value for cshtml
        // but now this prop will tracking the even handler "OnGet", so "FirstName" 's value will init
        // after doing following:
        return RedirectToPage();
    }
}