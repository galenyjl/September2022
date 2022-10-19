using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using September2022.Pages;
using September2022.Utilities;
using System;
using TechTalk.SpecFlow;

namespace September2022.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();

        [Given(@"I logged into turn up portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            driver = new ChromeDriver();

            // Login page object initialization and definition
            loginPageObj.LoginSteps(driver);
        }

        [When(@"I navaigate to Time and Material page")]
        public void WhenINavaigateToTimeAndMaterialPage()
        {
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create a new time and material record")]
        public void WhenICreateANewTimeAndMaterialRecord()
        {
            tmPageObj.CreateTM(driver);
        }

        [Then(@"The record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            string newCode = tmPageObj.GetCode(driver);
            string newDescription = tmPageObj.GetDescription(driver);
            string newPrice = tmPageObj.GetPrice(driver);

            Assert.That(newCode == "September2022", "New code and expected code do not match.");
            Assert.That(newDescription == "September2022", "New description and expected description do not match.");
            Assert.That(newPrice == "$12.00", "New price and expected price do not match.");
        }

        [When(@"I update '([^']*)' on an existing time and material record")]
        public void WhenIUpdateOnAnExistingTimeAndMaterialRecord(string description)
        {
            tmPageObj.EditTM(driver, description);
        }

        [Then(@"The record should have the updated '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string description)
        {
            string editedDescription = tmPageObj.GetEditedDescription(driver);
            Assert.That(editedDescription == description, "Actual desctription and expected description is not matched");
        }
    }
}
