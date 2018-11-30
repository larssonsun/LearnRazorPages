using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfirstrazorpages
{
    public class Sample
    {
        public string SampleName { get; set; }
        public string SampleId { set; get; }
        public string ItemId { get; set; }
    }

    public class SamplesForSelect
    {
        public SelectList Item_Samples { get; set; }

        public string SelectSampleId { get; set; }
    }
}