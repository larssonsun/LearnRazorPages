using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myfirstrazorpages.Services;

public class IocServicesModel : PageModel
{
    private IPrinter _printer;
    public IocServicesModel(IPrinter printer)//DI
    {
        _printer = printer;
    }

    [BindProperty]
    public string InputContent { get; set; }
    [BindProperty]
    public string PrintContent { get; set; }
    [TempData]
    public string SavedContent { get; set; }
    [TempData]
    public string PrintResult { set; get; }
    public void OnPostSave()
    {
        SavedContent = InputContent;
    }

    public void OnPostPrint()
    {
        _printer.Input(PrintContent);
        PrintResult = _printer.Print();
    }
}