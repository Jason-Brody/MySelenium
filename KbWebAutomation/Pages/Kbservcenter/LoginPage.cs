using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MySelenium;
using KbWebAutomation.Attributes;
using KbWebAutomation.Pages.SharedParameters;
using MySelenium.Models;
using KbWebAutomation.Models;

namespace KbWebAutomation.Pages.Kbservcenter {
    public class LoginPage :BasePage<RootPage,LoginParameter> {
        
       

        public void Login() {

            var parameter = Parameter.LoginInfo;
            if (parameter == null)
                throw new ArgumentNullException(nameof(LoginInfo));


            if (parameter.IsInnerUser) {
                parameter.UserName.ExistRun(Driver.GetVisualElement(By.Id("login-name-input")).SendKeys);
                parameter.Password.ExistRun(Driver.GetVisualElement(By.Id("pwd-input")).SendKeys);
                Driver.GetVisualElement(By.Id("login-btn")).Click();
            } else {
                IWebElement frame = Driver.FindElement(By.Id("J_loginIframe"));
                Driver.SwitchTo().Frame(frame);
                Driver.GetVisualElement(By.CssSelector("#J-input-user")).SendKeys(parameter.UserName);
                Driver.GetVisualElement(By.CssSelector("#password_input")).SendKeys(parameter.Password);
                Driver.GetVisualElement(By.CssSelector("#J-input-checkcode")).SendKeys("8888");
                Driver.GetVisualElement(By.CssSelector("#J-login-btn")).Click();
            }



        }

       

        public override bool IsNavigate() {
            return Driver.Url.Contains("login.htm");
        }

        public override RootPage FromPage() {
            return null;
        }

        public override void Navigate(RootPage FromPage) {
            if(Parameter.LoginInfo == null) 
                throw new ArgumentNullException(nameof(LoginInfo));
            
            Driver.Navigate().GoToUrl(Parameter.LoginInfo.Url);
        }
    }

   
}
