using NUnit.Framework;
using September2022.Pages;
using September2022.Utilities;

namespace September2022.Tests
{
    [TestFixture]
    [Parallelizable]
    public class Employee_Tests : CommonDriver
    {
        HomePage homepageObj = new HomePage();
        EmployeePage employeePageObj = new EmployeePage();

        [Test]
        public void CreateEmployeeTest()
        {
            homepageObj.GoToEmployeePage(driver);
            employeePageObj.CreateEmployee(driver);
        }

        [Test]
        public void EditEmployeeTest()
        {
            homepageObj.GoToEmployeePage(driver);
            employeePageObj.EditEmployee(driver);
        }

        [Test]
        public void DeleteEmployeeTest()
        {
            homepageObj.GoToEmployeePage(driver);
            employeePageObj.DeleteEmployee(driver);
        }
    }
}
