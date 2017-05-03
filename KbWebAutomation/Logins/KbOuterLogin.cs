using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MySelenium;

namespace KbWebAutomation.Logins {
    public class KbOuterLogin : ILogin {

        private IWebDriver _driver;
        public KbOuterLogin(IWebDriver driver) {
            _driver = driver;
        }

        public void Login(string userName, string password) {
            IWebElement frame = _driver.FindElement(By.Id("J_loginIframe"));
            _driver.SwitchTo().Frame(frame);
            _driver.FindElement(By.CssSelector("#J-input-user")).SendKeys(userName);
            _driver.FindElement(By.CssSelector("#password_input")).SendKeys(password);
            _driver.FindElement(By.CssSelector("#J-input-checkcode")).SendKeys("8888");
            _driver.FindElement(By.CssSelector("#J-login-btn")).Click();
        }
    }
}
