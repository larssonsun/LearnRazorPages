using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

public enum ItemType : int { Kind, Item, Sample, Parameter };
public class SelectTagHelperModel2 : PageModel
{
    [TempData]
    public string Msg { get; set; }
    [TempData]
    public int[] SelState { get; set; }

    [BindProperty]
    public int? SelectedTypeVal { get; set; }
    [BindProperty]
    public int? SelectedItemVal { get; set; }
    [BindProperty]
    public int? SelectedSampleVal { get; set; }

    public SelectList Samples { get; set; }

    public List<SelectListItem> Items { get; set; }

    public void OnGet()
    {
        if (SelState != null)
        {
            SelectedTypeVal = (int?)SelState[0];
            SelectedItemVal = (int?)SelState[1];
            SelectedSampleVal = (int?)SelState[2];
        }

        // source (new int[] { 1 }) should from db

        var source_items = (new int[] { 1 }).Select(x => new
        {
            ItemId = "1101",
            ItemName = "项目1",
            KindId = "11"
        }).ToList();
        source_items.Add(new
        {
            ItemId = "1102",
            ItemName = "项目2",
            KindId = "11"
        });

        var source_samples = (new int[] { 1 }).Select(x => new
        {
            SampleId = "110101",
            SampleName = "样品1",
            ItemId = "1101"
        }).ToList();
        source_samples.Add(new
        {
            SampleId = "110201",
            SampleName = "样品2",
            ItemId = "1101"
        });
        source_samples.Add(new
        {
            SampleId = "110202",
            SampleName = "样品3",
            ItemId = "1102"
        });

        //vm prop

        Samples = new SelectList(source_samples, "SampleId", "SampleName", null, "ItemId");
        // if the class is Strong type we should use nameof for each class prop 
        // to minimise the chances of typos creeping into the code. just like fllowing eg:

        // Staff = new SelectList(source_samples_strong, 
        // nameof(Sample.SampleId), 
        // nameof(Sample.SampleName), null, 
        // nameof(Sample.ItemId));


        // we can also use SelectListItem List
        Items = source_items.Select(x => new SelectListItem
        {
            Value = x.ItemId,
            Text = x.ItemName,
            Group = new SelectListGroup { Name = x.KindId }
        }).ToList();
    }
    public RedirectToPageResult OnPostSave()
    {
        SelState = new int[] { SelectedTypeVal.Value, SelectedItemVal.Value, SelectedSampleVal.Value };
        Msg = $"you select {SelectedTypeVal} {SelectedItemVal} {SelectedSampleVal}";
        return RedirectToPage();
    }
}