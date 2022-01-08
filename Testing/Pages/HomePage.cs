using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Testing.Utilities;

namespace Testing.Pages
{
    class HomePage
    {
      public void GoToTMPage(IWebDriver driver)
       {
        // click on administration button
        IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        administrationDropdown.Click();
         Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 2);
        // click on Time & Materials button
        IWebElement timeandmaterialsOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        timeandmaterialsOption.Click();
       }
    }
}
    
