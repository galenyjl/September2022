using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2022.Pages;
using September2022.Utilities;

namespace September2022.Tests
{
    [TestFixture]
    [Parallelizable]
    public class TM_Tests : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();

        [SetUp]
        public void LoginActions()
        {
            // open chrome browser

            driver = new ChromeDriver();

            // Login page object initialization and definition
            
            loginPageObj.LoginSteps(driver);

            // Home page object initialization and definition
            
            homePageObj.GoToTMPage(driver);
        }

        [Test, Order(1), Description ("This test creates a new TM record")]
        public void CreateTMTest()
        {
            
            tmPageObj.CreateTM(driver);
        }

        [Test, Order(2), Description ("This test edits the latest TM record created")]
        public void EditTMTest()
        {
            
            tmPageObj.EditTM(driver);
        }

        [Test, Order(3), Description ("This test deletes the TM record edited on the test above")]
        public void DeleteTMTest()
        {
            
            tmPageObj.DeleteTM(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }

    }
}
