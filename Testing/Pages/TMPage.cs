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
           // try
           // {

                // click on Create New button
                IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
                createNewButton.Click();

                //identify the Typecode dropdown and select from the dropdown.
                IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
                typeCodeDropdown.Click();
            Thread.Sleep(2000);
            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            materialOption.Click();
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
            Thread.Sleep(3000);
                // click on last page to see the entered data
                IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
                lastPageButton.Click();
            Thread.Sleep(3000);
                IWebElement actualCode= driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                IWebElement actualTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
                IWebElement actualDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
                IWebElement actualPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

                //Console.WriteLine("Material created Successfully");
            //}
           // catch (Exception ex)
            //{
               // Assert.Fail("Material not created successfully",ex.Message);
           // }

            Assert.That(actualCode.Text == "test", "Actual code and Expected code do not match.");
            Assert.That(actualTypeCode.Text == "M", "Actual typecode and Expected type do not match.");
            Assert.That(actualDescription.Text == "This is my first test", "Actual description and Expected description do not match.");
            Assert.That(actualPrice.Text == "$10,000.00","Actual price and Expected price do not match.");

        }

            public void EditMaterial(IWebDriver driver)
            {
            Thread.Sleep(3000);
            //try
            //{
            //Click on last page button
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            lastPageButton.Click();
            IWebElement findCreatedRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            Thread.Sleep(3000);
            if (findCreatedRecord.Text == "test")
            {
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
                Thread.Sleep(2000);
            }
            else
            {
                Assert.Fail("Record not found,Record cannot be edited");
            }
                //identify the code textbox and enter the valid code no more than 20 characters
                IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
                codeTextbox.Clear();
                codeTextbox.SendKeys("test1");


                //identify the description textbox and enter the valid description
                IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
                descriptionTextbox.Clear();
                descriptionTextbox.SendKeys("This is my edited test");

                //identify the price number and enter the valid price

                IWebElement priceBox = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));

                IWebElement priceNumerictextbox = driver.FindElement(By.Id("Price"));
                priceBox.Click();
                priceNumerictextbox.Clear();
                priceBox.Click();
                priceNumerictextbox.SendKeys("50000");

                // click on save button
                IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
                saveButton.Click();
                Thread.Sleep(4000);
                // click on last page to see the entered data
                IWebElement editLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                editLastPageButton.Click();
            Thread.Sleep(3000);
            //assertion
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            // Assertion
            Assert.That(editedCode.Text == "test1", "Actual code and expected code do not match.");
            Assert.That(editedTypeCode.Text == "M", "Actual typecode and expected typecode do not match.");
            Assert.That(editedDescription.Text == "This is my edited test", "Actual description and expected description do not match.");
            Assert.That(editedPrice.Text == "$50,000.00", "Actual price and expected price do not match.");


            // }
            //catch (Exception ex)
            //{
            // Assert.Fail("Material not edited successfully",ex.Message);
            // }
            // Assert.That(editedRecord.Text == "test1", "Actual edited record and Expected edited record do not match.");

        }

        public void DeleteMaterial(IWebDriver driver)
            {
            Thread.Sleep(2000);
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            lastPageButton.Click();
            IWebElement findEditedRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (findEditedRecord.Text == "test1")
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
               deleteButton.Click();
                Thread.Sleep(3000);
                driver.SwitchTo().Alert().Accept();

            }
            else
            {
                Assert.Fail("Record not found,Record cannot be deleted");
            }
            IWebElement deletelastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            deletelastpageButton.Click();
            IWebElement deletedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement deletedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement deletedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            // Assertion
            Assert.That(deletedCode.Text != "test2", "Code record hasn't been deleted.");
            Assert.That(deletedDescription.Text != "This is my edited1 test", "Description record hasn't beendeleted.");
            Assert.That(deletedPrice.Text != "$50,00.00", "Price record hasn't been deleted.");

        }

    }
}


