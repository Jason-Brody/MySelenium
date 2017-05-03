using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MySelenium;
using OpenQA.Selenium.Support.UI;
using KbWebAutomation.Attributes;
using static KbWebAutomation.Pages.Shared.ShareFunction;
using KbWebAutomation.Pages.SharedParameters;
using KbWebAutomation.Logins;

namespace KbWebAutomation.Pages.Kbservcenter.LeadsManagement {

    public class CreateLeadsParameter : LoginParameter {

        public ShopBaseInfo Shop { get; set; }

        public LicenseInfo License { get; set; }

        public OtherInfo Other { get; set; }

        public OtherDetailInfo OtherDetail { get; set; }
    }

    public class CreateLeadsPage : BasePage<PrivateLeadsPage, CreateLeadsParameter> {






        public void CreateLeads() {

            var shop = Parameter.Shop;
            if (shop == null)
                throw new ArgumentNullException(nameof(ShopBaseInfo));
            var license = Parameter.License;
            if(license == null)
                throw new ArgumentNullException(nameof(LicenseInfo));
            var other = Parameter.Other;
            if (other == null)
                throw new ArgumentNullException(nameof(OtherInfo));

            Driver.WaitPageLoad();

            


            CreateBaseInfo(Driver, Parameter.Shop);


            (Driver, 1, shop.HeadShopPic).ExistRun(UploadPic);


            foreach (var pic in shop.InnerShopPics.Split(';')) {
                UploadPic(Driver, 2, pic);
            }

            Driver.GetVisualElement(By.XPath("//div[text()='认证信息']")).ForceClick();



            if (!license.HasLicense)
                Driver.GetElement(By.XPath("//span[text()='证照正在办理']")).ForceClick();

            Driver.GetVisualElement(By.XPath("//div[text()='其他信息']")).ForceClick();

            Driver.GetVisualElement(By.XPath("//div[@role='combobox']")).ForceClick();


            


            Driver.GetElement(By.XPath($"//div[text()='{other.Brand}']")).ForceClick();
            other.User.ExistRun(Driver.GetElement(By.Id("kpName")).SendKeys);
            other.Telephone.ExistRun(Driver.GetElement(By.Id("kpTelNo")).SendKeys);

            Driver.GetClickableElement(By.CssSelector("button[type = 'submit']")).JClick();

            TimeWait.Get(10).Until(() => Driver.GetVisualElement(By.CssSelector("div.ant-modal-content")) != null);
        }

        public override bool IsNavigate() => Driver.Url.Contains("leads/new");

        public override PrivateLeadsPage FromPage() => new PrivateLeadsPage();

        public override void Navigate(PrivateLeadsPage FromPage) {

            Driver.GetClickableElement(FromPage.CreateLeadsButton, TimeSpan.FromSeconds(100)).Click();
        }
    }


}
