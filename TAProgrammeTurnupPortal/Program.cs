using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class Program
{
    public static void Main(string[] args)
    {

        //open chrome
        //IWebDriver driver = new ChromeDriver();
        var options = new ChromeOptions();

        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
        options.AddArgument("--disable-features=PasswordLeakDetection");
        //options.AddArgument("--user-data-dir=C:\\TempChromeProfile");

        IWebDriver driver = new ChromeDriver(options);

        //Launch Turnup portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
        driver.Manage().Window.Maximize();
        Thread.Sleep(1000);


        //Identify username textbox and enter valid username
        IWebElement usernametextbox = driver.FindElement(By.Id("UserName"));
        usernametextbox.SendKeys("hari");

        //Identify password textbox and enter valid passowrd
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");

        //Identify login button and check on it
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();
        Thread.Sleep(2000);

        //Check if user has logged in successfully 
        IWebElement helloUser = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        if (helloUser.Text == "Hello hari!")
        {
            Console.WriteLine("User has logged In successfully, Test passed. ");
        }
        else
        {
            Console.WriteLine("Test Failed");
        }


        /* Create Time and material new record */

        //Nevigate Time & material Page
        IWebElement admintrationTab = driver.FindElement(By.XPath("//a[normalize-space()='Administration']"));
        admintrationTab.Click();

        IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        timeAndMaterialOption.Click();

        //Click on create new button
        IWebElement clickCreateNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        clickCreateNewButton.Click();

        //Select the time from description
        IWebElement selectTypeCode = driver.FindElement(By.XPath("//span[contains(text(),'select')]"));
        selectTypeCode.Click();
        //Thread.Sleep(2000);

        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timeOption.Click();

        //Type code into code textbox
        IWebElement typeCode = driver.FindElement(By.Id("Code"));
        typeCode.SendKeys("TA Programme 999");

        //Type description into description textbox
        IWebElement typeDescription = driver.FindElement(By.Id("Description"));
        typeDescription.SendKeys("This is description for code 999.");

        //Type price into price textbox
        IWebElement priceTapOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTapOverlap.Click();

        IWebElement typePrice = driver.FindElement(By.Id("Price"));
        typePrice.SendKeys("17");

        //Click on save button
        IWebElement clickSaveButton = driver.FindElement(By.Id("SaveButton"));
        clickSaveButton.Click();
        Thread.Sleep(3000);

        //checked if time record has been created successfully
        IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPage.Click();

        IWebElement selectLastRow = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (selectLastRow.Text == "TA Programme 999") {

            Console.WriteLine("Time record created successfully.");
        }
        else
        {
            Console.WriteLine("Time record has not created.");
        }


        /* Edit Time record */

        // Click Edit button on last row
        IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        editButton.Click();

        //Edit code in the code textbox
        IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
        editCodeTextbox.Clear();
        editCodeTextbox.SendKeys("TA Programme 26 edit");

        //Edit description in description textbox
        IWebElement editDescriptionField = driver.FindElement(By.Id("Description"));
        editDescriptionField.Clear();
        editDescriptionField.SendKeys("This is edited description");
        
        //Edit price into price textbox
        IWebElement editPriceTapOverlap = driver.FindElement(By.XPath("//input[contains(@class,'k-formatted-value')]"));
        editPriceTapOverlap.Click();
        
        IWebElement editPrice = driver.FindElement(By.XPath("//input[@id='Price']"));
        editPrice.SendKeys(Keys.Control + "a");
        editPrice.SendKeys(Keys.Delete);
        editPrice.SendKeys("10");

        //click the save button
        IWebElement saveEditButton = driver.FindElement(By.Id("SaveButton"));
        saveEditButton.Click();
        Thread.Sleep(3000);

        //checked if time record has been edited successfully
        IWebElement goToLastPageCheckEditRow = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPageCheckEditRow.Click();

        IWebElement selectLastRowForEdited = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (selectLastRowForEdited.Text == "TA Programme 26 edit")
        {

            Console.WriteLine("Time record Edied successfully.");
        }
        else
        {
            Console.WriteLine("Time record has not edited.");
        }
       

        /* Delete Time record */

        //Click the delete button last row
        String codeValueLastRow = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Text;
        Console.WriteLine("codeValueLastRow : "+ codeValueLastRow);

        IWebElement clickDeleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
        clickDeleteButton.Click();

        //Click the Ok button 
        IAlert alert = driver.SwitchTo().Alert();
        alert.Accept();
        Thread.Sleep(2000);

        //checked if time record has been deleted successfully
        bool isRecordPresent = driver.PageSource.Contains(codeValueLastRow);

        if (!isRecordPresent)
        {
            Console.WriteLine("Time Record deleted successfully");
        }
        else
        {
            Console.WriteLine("Time Record still exists");
        }

    }
}
