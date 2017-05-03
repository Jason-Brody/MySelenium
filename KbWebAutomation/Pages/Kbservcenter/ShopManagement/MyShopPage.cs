using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySelenium;


namespace KbWebAutomation.Pages.Kbservcenter.ShopManagement {
    public class MyShopPage:BasePage<MainPage> {
       

        //创建门店
        public By CreateShopButton { get; private set; } = By.XPath("//span[text()='创建门店']");

        //创建单个门店
        public By CreateSingleShopLink { get; private set; } = By.XPath("//a[text()='创建单个门店']");


     

       

        public void CreateSingleShop() {
            TimeWait.Default.RunUntil(() => Driver.GetClickableElement(CreateShopButton).Click(),
                () => Driver.GetVisualElement(CreateSingleShopLink) != null
                );
            Driver.GetClickableElement(CreateSingleShopLink).Click();
        }

        public override MainPage FromPage() => new MainPage();

        public override bool IsNavigate() {
            return Driver.Url.Contains("shop");
        }

   

        public override void Navigate(MainPage FromPage) {
            FromPage.SelectMenu("门店管理", "我的门店");
        }
    }
}
