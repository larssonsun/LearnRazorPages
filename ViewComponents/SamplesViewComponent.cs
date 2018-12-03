using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfirstrazorpages;

namespace myfirstrazorpages.ViewComponents
{
    // should add the viewcomponent to _ViewImports.cshtml like following:
    //@addTagHelper *, myfirstrazorpages
    public class SamplesViewComponent : ViewComponent
    {
        public SamplesViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(string itemId)
        {
            var samples = await Task.Run(() =>
            {
                return new List<Sample> {
                    new Sample { SampleId = "110101", SampleName = "样品01" },
                    new Sample { SampleId = "110102", SampleName = "样品02" },
                    new Sample { SampleId = "120101", SampleName = "样品11" }
                };
            });

            var selectedValue = new SelectList(
                samples, nameof(Sample.SampleId), nameof(Sample.SampleName),
                $"{itemId}01", nameof(Sample.ItemId));
            return View(model: new SamplesForSelect { Item_Samples = selectedValue, Title = "im view component" });
        }
    }


}