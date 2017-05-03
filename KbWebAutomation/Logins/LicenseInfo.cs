using KbWebAutomation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KbWebAutomation.Logins {
    public class LicenseInfo {


        [SampleData(false)]
        public bool HasLicense { get; set; }


        [SampleData(@"E:\口碑素材\图片接口验证\2.jpg")]
        public string LicensePic { get; set; }


        public string AuthLetter { get; set; }

        public string Certificate { get; set; }

        public string OtherAutoInfo { get; set; }
    }
}
