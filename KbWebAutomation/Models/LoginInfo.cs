using KbWebAutomation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KbWebAutomation.Models {
    public class LoginInfo {
        [SampleData("chengyou.zy")]
        public string UserName { get; set; }

        [SampleData(null)]
        public string Password { get; set; }

        //[SampleData("http://antbuservice.stable.alipay.net/login.htm?loginChannel=PC&LOGIN_TYPE=bucSsoLoginHandler&goto=")]
        //[SampleData("https://crmhome.test.alipay.net/index.htm")]
        [SampleData("https://antbuservice.test.alipay.net/login.htm?loginChannel=PC&LOGIN_TYPE=bucSsoLoginHandler&goto=")]
        public string Url { get; set; }

        [SampleData(true)]
        public bool IsInnerUser { get; set; }

        [SampleData("8888")]
        public string AuthCode { get; set; }
    }
}
