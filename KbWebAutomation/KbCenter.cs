using KbWebAutomation.Logins;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySelenium;
using OpenQA.Selenium.Chrome;

namespace KbWebAutomation
{
    public class KbCenter
    {
        private IWebDriver _driver;

        public KbCenter() {


            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
        }

        public void Login(string userName, string password, string url) {
            _driver.Navigate().GoToUrl(url);
            ILogin login = new KbOuterLogin(_driver);
            login.Login(userName, password);
        }

        public void CreatePrivateLeads() {
            var e = _driver.FindElement(By.XPath("//span[text()='销售leads管理']/parent::div"));
            if (e.GetAttribute("aria-open") == "false") {
                e.Click();
            }
            _driver.FindElement(By.XPath("//li[text()='私海leads']")).Click();
            _driver.FindElement(By.XPath("//button/span[text()='创建单个leads']")).Click();
            _driver.FindElement(By.Id("headShopName")).SendKeys("Hello World");
           
        }



        //private string getUrl(bool isInnerUser, Env env) {



        //    if (isInnerUser && env == Env.Stable) {
        //        return "https://antbuservice.test.alipay.net/login.htm?loginChannel=PC&LOGIN_TYPE=bucSsoLoginHandler&goto=";
        //    }
        //    if (isInnerUser && env == Env.Test) {
        //        return "http://antbuservice.stable.alipay.net/login.htm?loginChannel=PC&LOGIN_TYPE=bucSsoLoginHandler&goto=";
        //    }
        //    if (!isInnerUser && env == Env.Test) {
        //        return "https://kbservcenter.test.alipay.net/kblogin.htm";
        //    }
        //    if (!isInnerUser && env == Env.Stable) {
        //        return
        //    }


        //}
    }
}
