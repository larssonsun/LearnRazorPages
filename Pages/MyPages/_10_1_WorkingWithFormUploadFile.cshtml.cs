using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class WorkingWithFormUploadFileModel : PageModel
{
    [BindProperty]
    public IFormFile Upfile { get; set; }
    public async Task OnPostAsync()
    {
        var file = $@"C:\Users\Larsson\Desktop\a_{Upfile.FileName}";
        using (var fileStream = new FileStream(file, FileMode.CreateNew))
        {
            await Upfile.CopyToAsync(fileStream);
        }
    }
}