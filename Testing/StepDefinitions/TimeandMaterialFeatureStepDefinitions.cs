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
        [When(@"I update '([^']*)' and '([^']*)' an existing time and material record\.")]
        public void WhenIUpdateAndAnExistingTimeAndMaterialRecord_(string Code, string Description)
        {
            tmPageObj.EditMaterial(driver,Code,Description);
        }
        [Then(@"the record should have an updated '([^']*)' and '([^']*)'\.")]
        public void ThenTheRecordShouldHaveAnUpdatedAnd_(string Code, string Description)
        {
            string editedCode = tmPageObj.GetEditedCode(driver);
            string editedDescription = tmPageObj.GetEditedDescription(driver);
            string editedTypeCode = tmPageObj.GetEditedTypeCode(driver);
            string editedPrice = tmPageObj.GetEditedPrice(driver);

            Assert.That(editedCode == Code, "Actual code and expected code do not match.");
            Assert.That(editedDescription == Description, "Actual description and expected description do not match.");
            Assert.That(editedTypeCode == "M", "Actual Typecode and expected Typecode do not match.");
            Assert.That(editedPrice == "$50,000.00", "Actual price and expected price do not match.");
        }
        [When(@"I deleted a time and material record\.")]
        public void WhenIDeletedATimeAndMaterialRecord_()
        {
            tmPageObj.DeleteMaterial(driver);
        }

        [Then(@"the record should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully()
        {
            string deletedCode = tmPageObj.GetDeletedCode(driver);
            string deletedDescription = tmPageObj.GetDeletedDescription(driver);
            string deletedPrice = tmPageObj.GetDeletedPrice(driver);

            Assert.That(deletedCode != "test3", "Actual code and expected code do not match.");
            Assert.That(deletedDescription != "edited test1", "Actual description and expected description do not match.");
            Assert.That(deletedPrice != "$60,000.00", "Actual price and expected price do not match."); 
        }

    }
}
