using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MySelenium;
using KbWebAutomation.Pages.SharedParameters;

namespace KbWebAutomation.Pages.Kbservcenter {
    public class MainPage :BasePage<LoginPage> {
        public override LoginPage FromPage() {
            return new LoginPage();
        }

        public override bool IsNavigate() {
            return Driver.Url.Contains("index.htm");
        }

        

        public override void Navigate(LoginPage FromPage) {
            FromPage.Login();
            Driver.WaitPageLoad();
            Driver.Navigate().GoToUrl("https://kbservcenter.test.alipay.net");
            //Driver.GetElement(By.XPath("//a[text()='口碑工作台']")).ExistRun(e => e.Click());
            
        }

        public void SelectMenu(string mainMenu,string subMenu) {
            string path = $"//span[contains(text(),'{mainMenu}')]/parent::div";

            var e = Driver.GetVisualElement(By.XPath(path));
            if (e.GetAttribute("aria-open") == "false") {
                e.ForceClick();
            }


            Driver.GetVisualElement(By.XPath($"//li[text()='{subMenu}']")).JClick();
        }
    }

   

    
}
