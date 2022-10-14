using NUnit.Framework;
using September2022.Pages;
using September2022.Utilities;

namespace September2022.Tests
{
    [TestFixture]
    [Parallelizable]
    public class TM_Tests : CommonDriver
    {
        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();

        [Test, Order(1), Description ("This test creates a new TM record")]
        public void CreateTMTest()
        {
            // Home page object initialization and definition
            homePageObj.GoToTMPage(driver);

            // TM page object initialization and definition
            tmPageObj.CreateTM(driver);
        }

        [Test, Order(2), Description ("This test edits the latest TM record created")]
        public void EditTMTest()
        {
            // Home page object initialization and definition
            homePageObj.GoToTMPage(driver);

            // Edit TM
            tmPageObj.EditTM(driver);
        }

        [Test, Order(3), Description ("This test deletes the TM record edited on the test above")]
        public void DeleteTMTest()
        {
            // Home page object initialization and definition
            homePageObj.GoToTMPage(driver);

            // Delete TM
            tmPageObj.DeleteTM(driver);
        }
    }
}
