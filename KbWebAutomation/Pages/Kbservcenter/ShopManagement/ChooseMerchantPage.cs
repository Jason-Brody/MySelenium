using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MySelenium;

namespace KbWebAutomation.Pages.Kbservcenter.ShopManagement {
    public class ChooseMerchantPage : BasePage<MyShopPage> {
   

        public override MyShopPage FromPage() => new MyShopPage();

        public override void Navigate(MyShopPage FromPage) {
            FromPage.CreateSingleShop();
        }

        public void ChooseMerchant(string merchant) {
            Driver.GetVisualElement(By.Id("partnerName")).ForceClick();


            TimeWait.Default.Until(() => 
                Driver.GetVisualElement(By.ClassName("ant-cascader-menu")).Displayed == true
            );

            TimeWait.Default.RunUntil(() => Driver.GetVisualElement(By.XPath($"//li[@title='{merchant}']")).JMouseOver(), () => 
                Driver.GetVisualElement(By.XPath("(//ul[@class='ant-cascader-menu'])[2]/li")).Displayed
            );


            Driver.GetVisualElement(By.XPath("(//ul[@class='ant-cascader-menu'])[2]/li")).ForceClick();



            var e1 = TimeWait.Default.GetUntil(() => Driver.GetVisualElement(By.XPath("//span[text()='创建门店']/parent::button")),
                e => e.Enabled);

            e1.ForceClick();

        }

        public override bool IsNavigate() {
            return Driver.Url.Contains("create#/shop/create");
        }
    }
}
