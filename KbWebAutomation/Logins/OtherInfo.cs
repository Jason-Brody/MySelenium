using KbWebAutomation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KbWebAutomation.Logins {
    public class OtherInfo {

        [SampleData("其它品牌")]
        public string Brand { get; set; }


        [SampleData("承佑")]
        public string User { get; set; }

        [SampleData("15800648661")]
        public string Telephone { get; set; }

        [SampleData(false)]
        public bool IsMcScan { get; set; }
    }
}
