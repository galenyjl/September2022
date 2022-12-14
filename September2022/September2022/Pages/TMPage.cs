using NUnit.Framework;
using OpenQA.Selenium;
using September2022.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace September2022.Pages
{
    public class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            try
            {
                // Click on "Create New" button
                IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
                createNewButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Create new button not found.", ex.Message);
            }

            // Select "Time" from the Typecode dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();
            Thread.Sleep(500);

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            timeOption.Click();

            // Enter code into the Code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("September2022");

            // Enter description into the Description textbox
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("September2022");

            // Enter price into the Price per unit textbox
            IWebElement inputTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            inputTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("12");

            // Click on "Save" button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(2000);

            // Check if new Time record has been created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
        }

        public string GetCode (IWebDriver driver)
        {
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }

        public string GetDescription (IWebDriver driver)
        {
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }

        public string GetPrice(IWebDriver driver)
        {
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPrice.Text;
        }

        public void EditTM(IWebDriver driver, string description, string code, string price)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 3);

            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(2000);

            IWebElement findRecordCreated = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findRecordCreated.Text == "FirstProject")
            {
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
                Thread.Sleep(2000);
            }
            else
            {
                Assert.Fail("Record to be edited hasn't been found. Record not edited");
            }

            //Edit the Typecode

            IWebElement typeCodeDropdown2 = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown2.Click();
            Thread.Sleep(500);
            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]"));
            materialOption.Click();


            //Edit the code
            IWebElement codeTextBox1 = driver.FindElement(By.Id("Code"));
            codeTextBox1.Clear();
            codeTextBox1.SendKeys(code);

            //Edit the Description

            IWebElement DescTextbox2 = driver.FindElement(By.Id("Description"));
            DescTextbox2.Clear();
            DescTextbox2.SendKeys(description);

            //Edit the Price 

            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span"));
            priceTag.Click();

            IWebElement pricePerUnit1 = driver.FindElement(By.Id("Price"));
            pricePerUnit1.Clear();

            priceTag.Click();
            pricePerUnit1.SendKeys(price);
            Thread.Sleep(2000);

            // Click on "Save" button
            IWebElement Savebutton2 = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
            Savebutton2.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 3);


            //Validate Edited Record

            //Goto last page and check last record

            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();
            Thread.Sleep(1500);

            IWebElement editedRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (editedRecord.Text == "editedcode1010")
            {
                Console.WriteLine("Record is edited successfully");
            }
            else
            {
                Console.WriteLine("OOPs can't edit the record");
            }
        }

        public string GetEditedDescription(IWebDriver driver)
        {
            IWebElement EditedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return EditedDescription.Text;
        }

        public string GetEditedCode(IWebDriver driver)
        {
            IWebElement EditedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return EditedCode.Text;
        }

        public string GetEditedPrice(IWebDriver driver)
        {
            IWebElement EditedPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return EditedPrice.Text;
        }

        public void DeleteTM(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 3);

            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(1000);

            IWebElement findEditedRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findEditedRecord.Text == "editedcode1010")
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(3000);

                driver.SwitchTo().Alert().Accept();
            }
            else
            {
                Assert.Fail("Edited code hasn't been found. Record not deleted");
            }

            // Click OK on Alert popup Window 

            driver.Navigate().Refresh();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 3);

            //VALIDATE DELETE
            IWebElement deletedRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));


            if (deletedRecord.Text != "editedcode1010")
            {
                Assert.Pass("Record has been deleted successfully ");
            }
            else
            {
                Assert.Fail("Record hasn't been deleted");
            }

        }
    }
}
