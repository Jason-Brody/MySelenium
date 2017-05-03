//using OpenQA.Selenium;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KbWebAutomation.Pages {
//    public abstract class BasePage<T> : BasePage {

//        public BasePage(IWebDriver driver) : base(driver) {

//        }
//        public new T Parameter { get => (T)base.Parameter; set => base.Parameter = value; }



//    }


//    public abstract class BasePage : IWebPage {
//        public IWebDriver Driver { get; private set; }

//        public object Parameter { get; set; }

//        public void ExistRun<T>(T parameter, Action<T> action) {
//            if (parameter != null) {
//                action(parameter);
//            }
//        }


//        public BasePage(IWebDriver driver) {
//            Driver = driver;
//        }

//        public abstract void Navigate(IWebPage FromPage);

//        public abstract bool IsNavigate();

//        public abstract BasePage FromPage();
//    }
//}
