using KbWebAutomation.Pages;
using KbWebAutomation.Pages.Kbservcenter.ShopManagement;
using MySelenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KbWebAutomation.Scripts {
    public class CreateShopFromKbScript : WebScript<CreateShopParameter> {
        public override void Run(CreateShopParameter parameter) {
            if(parameter == null) {
                parameter = DataUtils.GetSampleData<CreateShopParameter>();
            }

            parameter = DataUtils.GetSampleData<CreateShopParameter>();
           
            parameter.Shop.HeadShopName = $"页面自动化_{DateTime.Now}";
            var page = new CreateShopPage();
            NavigationUtil.NavigateTo(driver,page, parameter);
            page.CreateShop();
        }


    }
}
