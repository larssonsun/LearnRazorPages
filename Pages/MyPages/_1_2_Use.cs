using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

public class Par
{
    public string title { get; set; }
    public string[] shitbox { get; set; }
}

public class _1_2_Use : PageModel
{
    public string title = string.Empty;
    public Par par = null;

    public void OnGet()
    {
        par = new Par()
        {
            title = "this is shity!",
            shitbox = new[] { "10", "11", "12" }
        };
    }
}

