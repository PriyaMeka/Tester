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

        }
        public string GetCode(IWebDriver driver)
        {
            IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return actualCode.Text;
        }

        public string GetTypeCode(IWebDriver driver)
        {
            IWebElement actualTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            return actualTypeCode.Text;
        }
        public string GetDescription(IWebDriver driver)
        {
            IWebElement actualDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return actualDescription.Text;
        }
        public string GetPrice(IWebDriver driver)
        {
            IWebElement actualPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return actualPrice.Text;
        }

        public void EditMaterial(IWebDriver driver, string Code,string Description)
            {
            Thread.Sleep(3000);
            //Click on last page button
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            lastPageButton.Click();
            IWebElement findCreatedRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            Thread.Sleep(3000);
            //click on edit button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
                
                //identify the code textbox and enter the valid code no more than 20 characters
                IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
                codeTextbox.Clear();
                codeTextbox.SendKeys(Code);


                //identify the description textbox and enter the valid description
                IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
                descriptionTextbox.Clear();
                descriptionTextbox.SendKeys(Description);

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
        }
        public string GetEditedDescription(IWebDriver driver)
        {
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return editedDescription.Text;
        }
        public string GetEditedCode(IWebDriver driver)
        {
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return editedCode.Text;
        }
        public string GetEditedTypeCode(IWebDriver driver)
        {
            IWebElement editedTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            return editedTypeCode.Text;
        }
        public string GetEditedPrice(IWebDriver driver)
        {
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return editedPrice.Text;
        }

        public void DeleteMaterial(IWebDriver driver)
            {
            Thread.Sleep(2000);
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            lastPageButton.Click();
            IWebElement findEditedRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
               deleteButton.Click();
                Thread.Sleep(3000);
                driver.SwitchTo().Alert().Accept();

           
            IWebElement deletelastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            deletelastpageButton.Click();
        }
        public string GetDeletedCode(IWebDriver driver)
        {
            IWebElement deletedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return deletedCode.Text;
        }
        public string GetDeletedDescription(IWebDriver driver)
        {
            IWebElement deletedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return deletedDescription.Text;
        }
        public string GetDeletedPrice(IWebDriver driver)
        {
            IWebElement deletedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return deletedPrice.Text;
        }
    }
}


