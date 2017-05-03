//using MySelenium;
//using OpenQA.Selenium;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KbWebAutomation.Pages {
//    public static class NavigationUtil {
//        public static void NavigateTo<T>(BasePage<T> page, T parameter) {
//            Stack<BasePage> pages = new Stack<BasePage>();
//            BasePage myPage = page;
//            do {
//                pages.Push(myPage);
//                myPage = myPage.FromPage();
//            } while (myPage != null);
//            while (pages.Count > 0) {
//                var p = pages.Pop();
//                var tempPage = p.FromPage();
//                if (tempPage != null) {
//                    tempPage.Parameter = parameter;
//                }
//                p.Parameter = parameter;

//                p.Navigate(tempPage);
//                Console.WriteLine(p.GetType().Name);
//                Console.WriteLine(p.Parameter);
//                TimeWait.Default.Until(() => switchPage(p.Driver, p));
//            }
//        }

//        public static void NavigateTo(BasePage page, object parameter) {
//            Stack<BasePage> pages = new Stack<BasePage>();
//            BasePage myPage = page;
//            do {
//                pages.Push(myPage);
//                myPage = myPage.FromPage();
//            } while (myPage != null);
//            while (pages.Count > 0) {
//                var p = pages.Pop();
//                var tempPage = p.FromPage();
//                if (tempPage != null) {
//                    tempPage.Parameter = parameter;
//                }
//                p.Parameter = parameter;
//                p.Navigate(tempPage);
//                Console.WriteLine(p.GetType().Name);
//                Console.WriteLine(p.Parameter);
//                TimeWait.Default.Until(() => switchPage(p.Driver, p));
//            }
//        }


//        private static bool switchPage(IWebDriver driver, IWebPage page) {

//            if (page.FromPage() == null)
//                return true;
//            if (driver.WindowHandles.Count == 1)
//                return true;
//            foreach (var window in driver.WindowHandles) {

//                driver.SwitchTo().Window(window);
//                if (page.IsNavigate()) {
//                    return true;
//                }
//            }
//            return false;

//        }


//        public static T OfPage<T>(this IWebPage page) where T : class, IWebPage {
//            return page as T;
//        }
//    }
//}
