using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MySelenium;

namespace KbWebAutomation.Pages.CrmHome.ShopManagement {
    public class MyShopPage : BasePage<MainPage> {


        public override MainPage FromPage() => new MainPage();


        public override void Navigate(MainPage FromPage) {
            TimeWait.Get(60).Get(()=>Driver.GetVisualElement(FromPage.MyShop)).Click();
        }

        public void CreateSingleShop() {
            Driver.GetVisualElement(By.XPath("//span[text()='创建门店']/parent::button")).JMouseOver();
            Driver.GetVisualElement(By.XPath("//a[text()='创建单个门店']/parent::li")).ForceClick();
        }

        public override bool IsNavigate() => Driver.Url.Contains("shop");
    }
}
