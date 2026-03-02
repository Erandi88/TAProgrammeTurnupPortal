using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAProgrammeTurnupPortalNew.Utilities;

namespace TAProgrammeTurnupPortalNew.Pages
{
    public class LoginPage
    {
        public void LoginActions(IWebDriver driver) {

            //Launch Turnup portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            //Identify username textbox and enter valid username
            IWebElement usernametextbox = driver.FindElement(By.Id("UserName"));
            usernametextbox.SendKeys("hari");

            Wait.WaitToBeVisible(driver, "Id", "Password", 3);

            //Identify password textbox and enter valid passowrd
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            //Identify login button and check on it
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginButton.Click();
            Thread.Sleep(2000);
        }

    }
}
