using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MySelenium;

namespace KbWebAutomation.Pages.CrmHome {
    public class MainPage : BasePage<LoginPage> {


        
        public By MyShop { get; } = By.XPath("//a[@href='/shop.htm#/shop']");

        public override LoginPage FromPage() => new LoginPage();

        public override bool IsNavigate() {
            return Driver.Url.Contains("main.htm");
        }

        public override void Navigate(LoginPage FromPage) {
            FromPage.Login();
        }
    }
}
