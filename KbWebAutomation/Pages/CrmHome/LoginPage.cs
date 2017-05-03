using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MySelenium;
using KbWebAutomation.Pages.Kbservcenter;
using KbWebAutomation.Pages.SharedParameters;
using MySelenium.Models;
using KbWebAutomation.Models;

namespace KbWebAutomation.Pages.CrmHome {
    public class LoginPage : BasePage<RootPage,LoginParameter> {


        public override RootPage FromPage() => null;

        public override bool IsNavigate() {
            return Driver.Url.Contains("index.htm");
        }

        public void Login() {
            

            Driver.SwitchTo().Frame(TimeWait.Default.Get(()=>Driver.GetElement(By.Id("loginIframe"))));

            var parameter = Parameter.LoginInfo;
            if (parameter == null)
                throw new ArgumentNullException(nameof(LoginInfo));
            parameter.UserName.ExistRun(Driver.GetVisualElement(By.Id("J-input-user")).SendKeys);
            parameter.Password.ExistRun(Driver.GetVisualElement(By.Id("password_input")).SendKeys);
            Driver.GetVisualElement(By.Id("J-input-checkcode")).SendKeys("8888");
            Driver.GetVisualElement(By.Id("J-login-btn")).Submit();
        }

        

       

        public override void Navigate(RootPage FromPage) {
            Driver.Navigate().GoToUrl("https://crmhome.test.alipay.net/index.htm");
        }
    }
}
