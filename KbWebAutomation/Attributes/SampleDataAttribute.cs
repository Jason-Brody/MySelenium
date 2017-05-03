using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KbWebAutomation.Attributes {
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false,Inherited =true)]
    public class SampleDataAttribute:Attribute {

        public object Data { get; private set; }

        public SampleDataAttribute(object obj) {
            Data = obj;
        }

    }
}
