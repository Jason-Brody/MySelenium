using KbWebAutomation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KbWebAutomation.Logins {
    public class ShopBaseInfo {

        [SampleData("老子的分店")]
        public string ShopName { get; set; }

        [SampleData("老子的门店")]
        public string HeadShopName { get; set; }


        [SampleData("上海->上海市->浦东新区")]
        public string Area { get; set; }

        [SampleData("证大五道口广场29楼")]
        public string Address { get; set; }

        [SampleData("美食->中餐(不要打泛行业标)->川菜")]
        public string Category { get; set; }

        [SampleData("15800648661")]
        public string ShopTelephone { get; set; }


        [SampleData(@"E:\口碑素材\图片接口验证\2.jpg")]
        public string HeadShopPic { get; set; }


        [SampleData(@"E:\口碑素材\门店图片\1.jpg;E:\口碑素材\门店图片\2.jpg;E:\口碑素材\门店图片\3.jpg")]
        public string InnerShopPics { get; set; }
        //[SampleData("其它品牌")]
        //public string Brand { get; set; }
    }
}
