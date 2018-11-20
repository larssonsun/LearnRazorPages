using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class FormactionTagHelperModel : PageModel
{
    public Dictionary<string, string> Dict { get; set; }

    public void OnGet()
    {
        Dict = new Dictionary<string, string>
        {
            {"key1", "val1"},
            {"key2", "val2"}
        };
    }
}