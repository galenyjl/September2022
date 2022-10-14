using NUnit.Framework;
using OpenQA.Selenium;
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

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));


            Assert.That(newCode.Text == "September2022", "New code and expected code do not match.");
            Assert.That(newDescription.Text == "September2022", "New description and expected description do not match.");
            Assert.That(newPrice.Text == "$12.00", "New price and expected price do not match.");

        }

        public void EditTM(IWebDriver driver)
        {
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement findRecordCreated = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if(findRecordCreated.Text == "September2022")
            {
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
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
            codeTextBox1.SendKeys("editedcode1010");

            //Edit the Description

            IWebElement DescTextbox2 = driver.FindElement(By.Id("Description"));
            DescTextbox2.Clear();
            DescTextbox2.SendKeys("Edited /Updated description 1010");

            //Edit the Price 

            IWebElement priceInputTag2 = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceInputTag2.Click();
            IWebElement Price2 = driver.FindElement(By.Id("Price"));
            Price2.Clear();

            IWebElement priceInputTag3 = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceInputTag3.Click();
            IWebElement Price3 = driver.FindElement(By.Id("Price"));
            Price3.SendKeys("20");


            IWebElement Savebutton2 = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
            Savebutton2.Click();
            Thread.Sleep(2000);


            //Validate Edited Record

            //Goto last page and check last record

            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();

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

        public void DeleteTM(IWebDriver driver)
        {
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(1000);

            IWebElement findEditedRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findEditedRecord.Text == "editedcode1010")
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(500);
            }
            else
            {
                Assert.Fail("Edited code hasn't been found. Record not deleted");
            }

            // Click OK on Alert popup Window 

            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

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
