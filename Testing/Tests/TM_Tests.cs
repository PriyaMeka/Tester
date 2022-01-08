using Testing.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using NUnit.Framework;
using Testing.Utilities;

namespace Testing
{
    [TestFixture]
    [Parallelizable]
    class TM_Tests : CommonDriver

    {
          [Test, Order (1), Description("Check if user is able to create a Material record with valid data")]
       
        public void CreateMaterial_Test()
            {
            // Home page object initialization and definition 
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

            // TM page object initialization and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateMaterial(driver);
        }
        [Test, Order (2), Description("Check if user is able to edit a Material record with valid data")]

        public void EditMaterial_Test()
        {
            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

            // TM page object initialization and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.EditMaterial(driver);
        }
        
        [Test, Order (3), Description("Check if user is able to delete an existing material record")]
        public void DeleteMaterial_Test()
        {
            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

            // TM page object initialization and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.DeleteMaterial(driver);
        } //Test// //TearDown//
        

    }

}
