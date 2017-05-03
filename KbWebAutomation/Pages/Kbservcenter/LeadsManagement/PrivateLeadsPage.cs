using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MySelenium;

namespace KbWebAutomation.Pages.Kbservcenter.LeadsManagement {
    public class PrivateLeadsPage :BasePage<MainPage> {
       
        public By CreateLeadsButton { get; private set; } = By.XPath("//button/span[text()='创建单个leads']");

      
 

        public override bool IsNavigate() {
            return Driver.Url.Contains("private-leads");
        }

        public override void Navigate(MainPage FromPage) {
            FromPage.SelectMenu("销售leads", "私海leads");
        }

        public override MainPage FromPage() => new MainPage();
    }
}
