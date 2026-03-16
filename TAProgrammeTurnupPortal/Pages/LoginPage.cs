using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TAProgrammeTurnupPortalNew.Utilities;

namespace TAProgrammeTurnupPortalNew.Pages
{
    public class LoginPage
    {
        private readonly string url = "http://horse.industryconnect.io/";

        private readonly By userNameTextboxLocator = By.Id("UserName");
        IWebElement usernametextbox;

        private readonly By passwordTextBoxLocator = By.Id("Password");
        IWebElement passwordTextbox;

        private readonly By loginBtnLocator = By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]");
        IWebElement loginButton;

        public void LoginActions(IWebDriver driver, string userName, String password) {

            //Launch Turnup portal
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            //Exceptional Handling
            try
            {
                //Identify username textbox and enter valid username
                usernametextbox = driver.FindElement(userNameTextboxLocator);
                usernametextbox.SendKeys(userName);
            }
            catch (Exception ex) {

                Assert.Fail("UserName Textbox has not found. " +ex.Message);
           }

           Wait.WaitToBeVisible(driver, "Id", "Password", 3);

            //Identify password textbox and enter valid passowrd
            passwordTextbox = driver.FindElement(passwordTextBoxLocator);
            passwordTextbox.SendKeys(password);

            //Identify login button and check on it
            loginButton = driver.FindElement(loginBtnLocator);
            loginButton.Click();
            Thread.Sleep(2000);
        }

    }
}
