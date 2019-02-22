using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfirstrazorpages
{
    public class Kind
    {
        public string KindName { get; set; }
        public string KindId { set; get; }
    }
    
    public class Sample
    {
        public string SampleName { get; set; }
        public string SampleId { set; get; }
        public string ItemId { get; set; }
    }

    public class SamplesForSelect
    {
        public SelectList Item_Samples { get; set; }

        public string Title { get; set; }
    }
}