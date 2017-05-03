using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MySelenium;
using KbWebAutomation.Pages.Kbservcenter;
using static KbWebAutomation.Pages.Shared.ShareFunction;
using KbWebAutomation.Attributes;
using KbWebAutomation.Pages.SharedParameters;
using KbWebAutomation.Pages.Kbservcenter.LeadsManagement;

namespace KbWebAutomation.Pages.CrmHome.ShopManagement {

    public class CreateShopParameter :CreateLeadsParameter{

    }

    public class CreateShopPage : BasePage<MyShopPage,CreateShopParameter> {
       

        public override MyShopPage FromPage() => new MyShopPage();

       

        public override void Navigate(MyShopPage FromPage) {
            FromPage.CreateSingleShop();
        }

        public  void CreateShop() {
            Driver.GetVisualElement(By.XPath("//span[text()='直接创建门店']/parent::button")).ForceClick();


            CreateBaseInfo(Driver,Parameter.Shop);

            UploadPicV2(Driver,1, 1);
            UploadPicV2(Driver,2, 2);



           

            Driver.GetVisualElement(By.XPath("//div[text()='其他信息']")).ForceClick();

            Driver.GetVisualElement(By.XPath("//div[@role='combobox']")).ForceClick();


            Driver.GetElement(By.XPath($"//div[text()='{Parameter.Other.Brand}']")).ForceClick();
            Parameter.Other.User.ExistRun(Driver.GetElement(By.Id("kpName")).SendKeys);
            Parameter.Other.Telephone.ExistRun(Driver.GetElement(By.Id("kpTelNo")).SendKeys);








            //Driver.GetVisualElement(By.Id("headShopName")).SendKeys("xx老子的门店xx");
            //Driver.GetVisualElement(By.Id("shopName")).SendKeys("老子的分店");
            
            //selectMenu("area", "上海->上海市->浦东新区");
            //Driver.GetVisualElement(By.Id("address")).SendKeys("证大五道口广场29楼");


       
            //selectMenu("categoryIds", "美食->中餐(不要打泛行业标)->川菜");

            //uploadPicV2(1, 1);
            //uploadPicV2(2, 9);


            //TimeWait.Default.RunUntil(() => Driver.GetVisualElement(By.Id("certificate-info")).Click(), () => {
            //    Task.Delay(50).Wait();
            //    return Driver.GetVisualElement(By.Id("certificate-info")).GetAttribute("class").Contains("expanded");
            //}
                
            //);

            //Driver.GetElement(By.XPath("//span[text()='证照正在办理']")).Click();

            //TimeWait.Default.RunUntil(() => Driver.GetVisualElement(By.Id("other-info")).Click(), () =>
            //    Driver.GetVisualElement(By.Id("other-info")).GetAttribute("class").Contains("expanded")
            //);



            //var e = Driver.GetClickableElement(By.XPath("//div[@role='combobox']"));

            //TimeWait.Default.RunUntil(() => e.Click(), () => Driver.GetVisualElement(By.XPath("//div[text()='其它品牌']")) != null);

           
            //Driver.GetElement(By.XPath("//div[text()='其它品牌']")).Click();
            //Driver.GetElement(By.Id("kpName")).SendKeys("承佑");
            //Driver.GetElement(By.Id("kpTelNo")).SendKeys("15800648661");


        }

        public override bool IsNavigate() => Driver.Url.Contains("/shop/create");
        
    }
}
