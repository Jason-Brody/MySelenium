using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MySelenium;
using OpenQA.Selenium.Support.UI;
using KbWebAutomation.Pages.SharedParameters;
using KbWebAutomation.Logins;

namespace KbWebAutomation.Pages.Shared {

    
    


    public static class ShareFunction {
       

        public static void UploadPic(IWebDriver Driver,int id, string pic) {
            var e = Driver.GetVisualElement(By.XPath($"(//div[@class='ant-upload ant-upload-select ant-upload-select-picture-card'])[{id}]"));
            e = e.GetElement(By.CssSelector("input[type='file']"));
            e.SendKeys(pic);
            Task.Delay(50).Wait();
            TimeWait.Default.Until(() => Driver.GetElement(By.XPath("//div[text()='文件上传中']")) == null);
            
        }

        public static void UploadPicV2(IWebDriver Driver,int id, int num) {
            Task.Delay(50);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"(//div[@class='ant-upload ant-upload-select ant-upload-select-picture-card'])[{id}]")));

            Task.Delay(500).Wait();
         
            Driver.GetClickableElement(By.XPath($"(//div[@class='ant-upload ant-upload-select ant-upload-select-picture-card'])[{id}]")).Click();
            
            
            TimeWait.Default.GetUntil(() => Driver.FindElements(By.CssSelector("div.hermes-photo-picker-list-item img")), t => t.Count > 0 && t.First().Displayed).Take(num).ToList().ForEach(e => e.Click());
            Driver.GetClickableElement(By.XPath("//span[text()='确 定']")).Click();
        }


        public static void SelectMenu(IWebDriver Driver,string id,string menu) {

            Driver.GetClickableElement(By.Id(id)).JClick();
            Task.Delay(500).Wait();
            string[] menus = menu.Split(new string[] { "->" }, StringSplitOptions.None);
            for (int i = 0; i < menus.Count(); i++) {
                var e = Driver.GetClickableElement(By.CssSelector($"li[title='{menus[i]}']"));
                
                if (i == menus.Count() - 1) {
                    
                    e.JClick();
                } else {
                    e.JMouseOver();
                    
                    //Task.Delay(300).Wait();
                    //TimeWait.Default.RunUntil(() => e.MouseOver(),
                    //   () => Driver.GetVisualElement(By.CssSelector($"li[title='{menus[i+1]}']")) != null);

                }
            }
        }

        public static void CreateBaseInfo(IWebDriver Driver,ShopBaseInfo Parameter) {
            Parameter.HeadShopName.ExistRun(Driver.GetVisualElement(By.Id("headShopName")).SendKeys);
            Parameter.ShopName.ExistRun(Driver.GetVisualElement(By.Id("shopName")).SendKeys);



            (Driver,"area", Parameter.Area).ExistRun(SelectMenu);

            Parameter.Address.ExistRun(Driver.GetVisualElement(By.CssSelector("#address")).SendKeys);

            (Driver,"categoryIds", Parameter.Category).ExistRun(SelectMenu);

            Parameter.ShopTelephone.ExistRun(Driver.GetVisualElement(By.CssSelector("#addable-inputValue-1")).SendKeys);
        }
    }
}
