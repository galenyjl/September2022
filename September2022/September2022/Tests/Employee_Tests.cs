using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using September2022.Pages;
using September2022.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace September2022.Tests
{
    [TestFixture]
    [Parallelizable]
    public class Employee_Tests : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homepageObj = new HomePage();
        EmployeePage employeePageObj = new EmployeePage();

        [SetUp]
        public void LoginActions()
        {
            // open chrome browser

            driver = new ChromeDriver();

            // Login page object initialization and definition
            
            loginPageObj.LoginSteps(driver);

            
            homepageObj.GoToEmployeePage(driver);
        }

        [Test]
        public void CreateEmployeeTest()
        {
            
            employeePageObj.CreateEmployee(driver);
        }

        [Test]
        public void EditEmployeeTest()
        {
           
            employeePageObj.EditEmployee(driver);
        }

        [Test]
        public void DeleteEmployeeTest()
        {
            
            employeePageObj.DeleteEmployee(driver);
        }

        [TearDown]
        public void ClosingSteps()
        {
            driver.Quit();
        }
    }
}
