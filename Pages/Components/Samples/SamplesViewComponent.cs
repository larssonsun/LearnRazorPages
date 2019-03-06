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

            var extSelList = new SelectList(
                samples, nameof(Sample.SampleId), nameof(Sample.SampleName),
                $"{itemId}01", nameof(Sample.ItemId));

            // use default view of the viewcomponent (Omit the default view of the viewconponent, named "default")
            return View(model: new SamplesForSelect { Item_Samples = extSelList, Title = "im default view component" });

            // use sampleuc_hntky view of the viewconponent
            // return View("hntky", model:new SampleUc_Hntky{ Title="我是sampleuc_hntky", Item_Samples = extSelList});
        }
    }


}