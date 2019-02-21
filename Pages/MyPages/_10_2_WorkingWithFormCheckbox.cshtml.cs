using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class WorkingWithFormCheckboxModel : PageModel
{

    [TempData]
    public string Message { get; set; }

    [BindProperty]
    public bool SingleChecked { get; set; }

    [BindProperty]
    public bool SingleCheckedWithNoTagHelper { get; set; }

    [BindProperty]
    public List<Parameter> MultiplChecked { get; set; } = new List<Parameter>();
    [BindProperty]
    public List<Parameter> MultiplChecked2 { get; set; } = new List<Parameter>();
    public void OnGet()
    {
        MultiplChecked.Add(new Parameter() { ParameterName = "安定性", ParameterId = "110101101", Checked = false });
        MultiplChecked.Add(new Parameter() { ParameterName = "标准稠度用水量", ParameterId = "110101102", Checked = false });
        MultiplChecked.Add(new Parameter() { ParameterName = "初凝时间", ParameterId = "110101103", Checked = false });
        MultiplChecked.Add(new Parameter() { ParameterName = "终凝时间", ParameterId = "110101104", Checked = false });
        MultiplChecked.Add(new Parameter() { ParameterName = "比表面积", ParameterId = "110101106", Checked = false });

        MultiplChecked2.Add(new Parameter() { ParameterName = "安定性", ParameterId = "110101101", Checked = false });
        MultiplChecked2.Add(new Parameter() { ParameterName = "标准稠度用水量", ParameterId = "110101102", Checked = false });
        MultiplChecked2.Add(new Parameter() { ParameterName = "初凝时间", ParameterId = "110101103", Checked = false });
        MultiplChecked2.Add(new Parameter() { ParameterName = "终凝时间", ParameterId = "110101104", Checked = false });
        MultiplChecked2.Add(new Parameter() { ParameterName = "比表面积", ParameterId = "110101106", Checked = false });
        Console.WriteLine("-----onget-----");
    }

    public void OnPostShowResult()
    {
        Message = $"SingleChecked{SingleChecked}";

    }

    public void OnPostShowResult2()
    {
        Message = $"SingleCheckedWithNoTagHelper{SingleCheckedWithNoTagHelper}";
    }

    public RedirectToPageResult OnPostShowResult3()
    {
        string result = string.Empty;
        var shit = MultiplChecked.Where(x => x.Checked == true);
        shit.ToList().ForEach(x => result += $",{x.ParameterId}");
        Message = $"MultiplChecked: {result}";
        return RedirectToPage();
    }

    public RedirectToPageResult OnPostShowResult4()
    {
        string result = string.Empty;
        var shit = MultiplChecked2.Where(x => x.Checked == true);
        shit.ToList().ForEach(x => result += $",{x.ParameterId}");
        Message = $"MultiplChecked2: {result}";
        return RedirectToPage();
    }
}

public class Parameter
{
    public string ParameterId { get; set; }
    public string ParameterName { get; set; }
    public bool Checked { get; set; }
}