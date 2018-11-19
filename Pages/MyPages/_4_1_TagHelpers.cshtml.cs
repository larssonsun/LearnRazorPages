using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class TagHelpers : PageModel
{
    public Dictionary<string, string> Dict { get; set; }

    public void OnGet()
    {
        Console.WriteLine("OnGet()!");
        Dict = new Dictionary<string, string>(){
            {"key1", "val1"},
            {"key2", "val2"}
        };
    }
    public void OnGetShityAction()
    {
        Console.WriteLine("ShityAction()!");
    }
}