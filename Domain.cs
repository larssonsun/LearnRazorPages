using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Primitives;

namespace myfirstrazorpages
{
    public class Kind
    {
        public string KindName { get; set; }
        public string KindId { set; get; }

        public SelectList SelItems { get; set; }
    }

    public class Item
    {
        public string ItemName { get; set; }
        public string ItemId { get; set; }
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

    public class SampleUc_Hntky
    {
        public string Title { get; set; }

        public SelectList Item_Samples { get; set; }
    }

    // 自定义的IChangeToken实例，实际使用应该由某个实例返回一个IChangeToken对象
    public class MyChangeToken : IChangeToken
    {
        public Func<bool> kindChanged;
        public bool HasChanged
        {
            get
            {
                bool tmp = kindChanged();
                Console.WriteLine($"KindChanged = {tmp}");
                return tmp;
            }
        }

        public bool ActiveChangeCallbacks => false;

        public IDisposable RegisterChangeCallback(Action<object> callback, object state)
        {
            throw new NotImplementedException();
        }
    }

    public class IfKindChanged
    {
        private string _orgKindid;// 这里也可以是从持久化数据种得到kindid
        private string _currentKindId;

        public IfKindChanged(string kindId, string comepareVal)
        {
            _currentKindId = kindId;
            _orgKindid = comepareVal;// 这里也可以是从持久化数据种得到kindid
        }

        public IChangeToken Watch() => new MyChangeToken()
        {
            kindChanged = () =>
            {
                return _orgKindid != _currentKindId;
            }
        };

    }
}