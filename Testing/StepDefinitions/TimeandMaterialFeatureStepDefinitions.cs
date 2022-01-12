using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using Testing.Pages;
using Testing.Utilities;

namespace Testing.StepDefinitions
{
    [Binding]
    public class TimeandMaterialFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();

        [Given(@"Logged into turnup portal successfully")]
        public void GivenLoggedIntoTurnupPortalSuccessfully()
        {
            driver = new ChromeDriver();
            // Home page object initialization and definition
            loginPageObj.Login(driver);
        }

        [Given(@"Navigate to time and material page\.\.")]
        public void GivenNavigateToTimeAndMaterialPage_()
        {
            // Home page object initialization and definition 
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I created a time and material record\.")]
        public void WhenICreatedATimeAndMaterialRecord_()
        {
            // TM page object initialization and definition
            tmPageObj.CreateMaterial(driver);
        }

        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            string actualCode = tmPageObj.GetCode(driver);
            string actualTypeCode = tmPageObj.GetTypeCode(driver);
            string actualDescription = tmPageObj.GetDescription(driver);
            string actualPrice = tmPageObj.GetPrice(driver);


            Assert.That(actualCode == "test", "Actual code and Expected code do not match.");
            Assert.That(actualTypeCode == "M", "Actual typecode and Expected type do not match.");
            Assert.That(actualDescription == "This is my first test", "Actual description and Expected description do not match.");
            Assert.That(actualPrice == "$10,000.00", "Actual price and Expected price do not match.");

        }
        [When(@"I update '([^']*)' an existing time and material record\.")]
        public void WhenIUpdateAnExistingTimeAndMaterialRecord_(string description)
        {
            tmPageObj.EditMaterial(driver, description);
        }

        [Then(@"the record should have an updated '([^']*)'\.")]
        public void ThenTheRecordShouldHaveAnUpdated_(string description)
        {
            string editedDescription = tmPageObj.GetEditedDescription(driver);
            Assert.That(editedDescription == description, "Actual description and expected description do not match.");

        }
    }
}
