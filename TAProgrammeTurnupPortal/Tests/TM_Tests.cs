using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAProgrammeTurnupPortalNew.Pages;
using TAProgrammeTurnupPortalNew.Utilities;

namespace TAProgrammeTurnupPortalNew.Tests
{
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        TMPage tmPageObj = new TMPage(); //Time Material page bject initialization

        LoginPage loginPageObj = new LoginPage(); //Login page object initialization
        
        HomePage homePageObj = new HomePage(); //Home page object initialization

        [SetUp]
        public void SetUpSteps()
        {
            // Configure Chrome browser settings to disable password popup
            var options = new ChromeOptions();

            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            options.AddArgument("--disable-features=PasswordLeakDetection");
            //options.AddArgument("--user-data-dir=C:\\TempChromeProfile");

            // Launch Chrome browser
            driver = new ChromeDriver(options);

            // Perform login to the application
            loginPageObj.LoginActions(driver, "hari", "123123");

            // Navigate to Time & Material page
            homePageObj.NavigateToTMPage(driver);

        }

        [Test]
        public void CreateTime_Test() 
        {
            tmPageObj.CreateNewTimeAndMaterialRecord(driver);
        }

        [Test]
        public void EditTime_Test() 
        {
            tmPageObj.EditTimeAndMaterialRecord(driver);
        }

        [Test]
        public void DeleteTime_Test() 
        {
           tmPageObj.DeleteTimeAndMaterialRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }

    }
}
