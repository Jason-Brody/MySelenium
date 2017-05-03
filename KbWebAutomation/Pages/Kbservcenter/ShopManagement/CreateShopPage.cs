using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MySelenium;
using static KbWebAutomation.Pages.Shared.ShareFunction;
using KbWebAutomation.Attributes;
using KbWebAutomation.Pages.SharedParameters;
using KbWebAutomation.Pages.Kbservcenter.LeadsManagement;

namespace KbWebAutomation.Pages.Kbservcenter.ShopManagement {

    public class CreateShopParameter:CreateLeadsParameter {
       
        [SampleData("nimei007")]
        public string Merchant { get; set; }
    }

    public class CreateShopPage : BasePage<ChooseMerchantPage,CreateShopParameter> {
       

        public override ChooseMerchantPage FromPage() => new ChooseMerchantPage();

        

        public override void Navigate(ChooseMerchantPage FromPage) {
            FromPage.ChooseMerchant(Parameter.Merchant);
        }

        public void CreateShop() {
            var shop = checkNull(Parameter.Shop);
            var license = checkNull(Parameter.License);
            var other = checkNull(Parameter.Other);


            CreateBaseInfo(Driver,Parameter.Shop);

            UploadPicV2(Driver,1, 1);
            UploadPicV2(Driver,2, 2);



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




            //Driver.GetVisualElement(By.Id("headShopName")).SendKeys("xx老子的门店xx");
            //Driver.GetVisualElement(By.Id("shopName")).SendKeys("老子的分店");

            //selectMenu("area","上海->上海市->浦东新区");
            //Driver.GetVisualElement(By.Id("address")).SendKeys("证大五道口广场29楼");



            //selectMenu("categoryIds", "美食->中餐(不要打泛行业标)->川菜");

            //uploadPicV2(1, 1);
            //uploadPicV2(2, 9);


            //TimeWait.Default.RunUntil(() => Driver.GetVisualElement(By.Id("certificate-info")).Click(), () => 
            //    Driver.GetVisualElement(By.Id("certificate-info")).GetAttribute("class").Contains("expanded")
            //);

            //Driver.GetElement(By.XPath("//span[text()='证照正在办理']")).Click();

            //TimeWait.Default.RunUntil(() => Driver.GetVisualElement(By.Id("other-info")).Click(), () =>
            //    Driver.GetVisualElement(By.Id("other-info")).GetAttribute("class").Contains("expanded") 
            //);

            //var e = Driver.GetVisualElement(By.XPath("//div[@role='combobox']"));
            //TimeWait.Default.RunUntil(() => e.Click(), () => {
            //    var e1 = Driver.GetElement(By.XPath("//div[text()='其它品牌']"));
            //    if (e1 == null || e1.Displayed == false)
            //        return false;
            //    return true;
            //});


            //Driver.GetElement(By.XPath("//div[text()='其它品牌']")).Click();
            //Driver.GetElement(By.Id("kpName")).SendKeys("承佑");
            //Driver.GetElement(By.Id("kpTelNo")).SendKeys("15800648661");
        }

        

        public override bool IsNavigate() {
            return Driver.Url.Contains("create#/shop/create");
        }

       
    }
}
