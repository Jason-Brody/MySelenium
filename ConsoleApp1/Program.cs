using KbWebAutomation;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySelenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using KbWebAutomation.Pages;
using KbWebAutomation.Pages.Kbservcenter.ShopManagement;
using KbWebAutomation.Pages.Kbservcenter.LeadsManagement;
using KbWebAutomation.Scripts;
using System.Reflection;
using KbWebAutomation.Logins;
using KbWebAutomation.Models;

namespace ConsoleApp1 {
    class Program {

        

        static void Main(string[] args) {

            var dbContext = new DemoEntities();

            var item = new Table() { Id = 2, Name = "ZY", Age = 11 };
            dbContext.Table.Add(item);

            dbContext.SaveChanges();


            item.Name = "HELLO WORLD";
            item.Age = 18;

            dbContext.SaveChanges();


            var items = dbContext.Table.Where(a => a.Age > 50).OrderBy(a=>a.Name).ToList();


            List<Student> students = new List<Student>();
            

            
            

            //var asm =  Assembly.GetExecutingAssembly();
            // asm.GetTypes().Where(t=>t.IsInstanceOfType(typeof(IScript<T>)))

            //var a = typeof(CreateLeadsScript).GetInterfaces().First();
            //var b = a.GetGenericTypeDefinition();

            //CreateLeadsParameter parameter = new CreateLeadsParameter();
            //parameter = new CreateLeadsParameter();
            //parameter.LoginInfo = DataUtils.GetSampleData<LoginInfo>();
            //parameter.Shop = DataUtils.GetSampleData<ShopBaseInfo>();
            //parameter.License = DataUtils.GetSampleData<LicenseInfo>();
            //parameter.Other = DataUtils.GetSampleData<OtherInfo>();
            //parameter.OtherDetail = DataUtils.GetSampleData<OtherDetailInfo>();


            CreateLeadsParameter parameter = DataUtils.GetSampleData<CreateLeadsParameter>();


            var page = new CreateLeadsPage();
            NavigationUtil.NavigateTo(null,page, parameter);
            page.CreateLeads();

            parameter.SaveAsJson("test.json");

            Student s = new Student();
            
        }



       


       

    }

    


    public class Student {

        private int age;

        public string Name { get; set; }

        public int Age() => age++;

        public T Get<T>() where T : new() {
            return new T();
        }

    }


    

}
