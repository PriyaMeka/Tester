using Testing.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Testing
{
    class TM_Tests

    {
        static void Main(string[] args)
        {
            // open chrome browser
            IWebDriver driver = new ChromeDriver();
            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.Login(driver); 
            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
            // TM page object initialization and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateMaterial(driver);
            // Edit page object initialization and definition
            tmPageObj.EditMaterial(driver);
            // Delete page object initialization and definition
            tmPageObj.DeleteMaterial(driver);
        }

    }

}
