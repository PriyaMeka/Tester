using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Testing.Utilities;

namespace Testing.Pages
{
    class TMPage
    {
      public void CreateMaterial(IWebDriver driver)
            {
            try
            {
                    // click on Create New button
                    IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
                    createNewButton.Click();

                    //identify the Typecode dropdown and select from the dropdown.
                    IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
                    typeCodeDropdown.Click();
                    Wait.WaitToBeClickable(driver,"Id","Code",3);

                    //identify the code textbox and enter the valid code no more than 20 characters
                    IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
                    codeTextbox.SendKeys("test");

                    //identify the description textbox and enter the valid description
                    IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
                    descriptionTextbox.SendKeys("This is my first test");

                    //identify the price number and enter the valid price

                    IWebElement priceBox = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
                    priceBox.Click();

                    IWebElement priceNumerictextbox = driver.FindElement(By.Id("Price"));
                    priceNumerictextbox.SendKeys("10000");

                    // click on save button
                    IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
                    saveButton.Click();
                    Wait.WaitToBeClickable(driver,"XPath","//*[@id='tmsGrid']/div[4]/a[4]/span",4);

                    // click on last page to see the entered data
                    IWebElement lastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                    //*[@id='tmsGrid']/div[4]/a[4]/span
                    lastpageButton.Click();
                    Wait.WaitToBeClickable(driver,"XPath","//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]",4);
                   
                    IWebElement actualRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                    Console.WriteLine("Material created Successfully");

                }
                catch (Exception ex)
                {
                    Assert.Fail("material not created successfully", ex.Message);
                }
            }

            public void EditMaterial(IWebDriver driver)
            {
                try
                {
                    IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                    editButton.Click();
                    Wait.WaitToBeClickable(driver,"Id","Code",4);



                //identify the code textbox and enter the valid code no more than 20 characters
                IWebElement editcodeTextbox = driver.FindElement(By.Id("Code"));
                    editcodeTextbox.Clear();
                    editcodeTextbox.SendKeys("test1");
                    Wait.WaitToBeClickable(driver,"Id","Description",4);


                //identify the description textbox and enter the valid description
                IWebElement editdescriptionTextbox = driver.FindElement(By.Id("Description"));
                    editdescriptionTextbox.Clear();
                    editdescriptionTextbox.SendKeys("This is my edited test");
                   Wait.WaitToBeClickable(driver,"XPath","//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]",4);

                //identify the price number and enter the valid price

                IWebElement editpriceBox = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));

                    IWebElement editpriceNumerictextbox = driver.FindElement(By.Id("Price"));
                    editpriceBox.Click();
                    editpriceNumerictextbox.Clear();
                    editpriceBox.Click();
                    editpriceNumerictextbox.SendKeys("50000");
                     Wait.WaitToBeClickable(driver, "Id","SaveButton",4);


                // click on save button
                IWebElement editsaveButton = driver.FindElement(By.Id("SaveButton"));
                    editsaveButton.Click();
                    Wait.WaitToBeClickable(driver,"XPath","//*[@id='tmsGrid']/div[4]/a[4]/span",4);

                // click on last page to see the entered data
                IWebElement editlastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                    editlastpageButton.Click();
                    Wait.WaitToBeClickable(driver,"XPath","//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]",4);


                IWebElement editedRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                    Console.WriteLine("Material edited Successfully");
                }
                catch (Exception ex)
                {
                    Assert.Fail("material not edited successfully", ex.Message);
                }
            }

            public void DeleteMaterial(IWebDriver driver)
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            Wait.WaitToBeClickable(driver,"XPath","//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]",4);
            driver.SwitchTo().Alert().Accept();
            Console.WriteLine("Material deleted successfully");
            }
        
    }
}


