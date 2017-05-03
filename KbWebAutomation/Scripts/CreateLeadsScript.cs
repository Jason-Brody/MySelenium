using KbWebAutomation.Pages.Kbservcenter.LeadsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KbWebAutomation.Pages;
using MySelenium;
using KbWebAutomation.Logins;
using KbWebAutomation.Models;

namespace KbWebAutomation.Scripts {
    public class CreateLeadsScript:WebScript<CreateLeadsParameter> {

        

        public override void Run(CreateLeadsParameter parameter) {
            
                parameter = new CreateLeadsParameter();
                parameter.LoginInfo = DataUtils.GetSampleData<LoginInfo>();
                parameter.Shop = DataUtils.GetSampleData<ShopBaseInfo>();
                parameter.License = DataUtils.GetSampleData<LicenseInfo>();
                parameter.Other = DataUtils.GetSampleData<OtherInfo>();
                parameter.OtherDetail = DataUtils.GetSampleData<OtherDetailInfo>();

            


            parameter.Shop.HeadShopName = $"页面自动化_{DateTime.Now}";
            //LoginParameter parameter = new LoginParameter();

            //parameter.IsInnerUser = true;
            //parameter.Url = "https://antbuservice.test.alipay.net/login.htm?loginChannel=PC&LOGIN_TYPE=bucSsoLoginHandler&goto=";
            //parameter.UserName = "chengyou.zy";

            //var page = new PrivateLeadsPage(driver);
            var page = new CreateLeadsPage();
            NavigationUtil.NavigateTo(driver,page, parameter);
            page.CreateLeads();
        }

    }
}
