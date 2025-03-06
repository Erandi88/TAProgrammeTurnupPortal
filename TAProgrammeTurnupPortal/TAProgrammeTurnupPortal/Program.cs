using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {
        //open chrome browser
        IWebDriver driver = new ChromeDriver();

        //launch Turnup portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
        driver.Manage().Window.Maximize(); // screen resolution 
        Thread.Sleep(1000);

        //identify username & enter valid username
        IWebElement userNameTextbox = driver.FindElement(By.Id("UserName"));
        userNameTextbox.SendKeys("hari");
        

        //identify password & enter valid password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");

        //identify login button & click on it

        //IWebElement loginBtn = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        IWebElement loginBtn = driver.FindElement(By.XPath("//input[@value='Log in']"));
        loginBtn.Click();
        Thread.Sleep(2000);

        //check if user logged in successfully
        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        if(helloHari.Text == "Hello hari!")
        {
            Console.WriteLine("User has loggied in successfully. Test is passed");
        }
        else
        {
            Console.WriteLine("User has not loggied in. Test is failed");
        }


        /************************** create time & material new record *********************************************/
        

        // navigate time & material page
        IWebElement admintativeTab = driver.FindElement(By.XPath("//a[normalize-space()='Administration']"));
        admintativeTab.Click();

        IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("//a[normalize-space()='Time & Materials']"));
        timeAndMaterialOption.Click();

        // click on create new btn
        IWebElement createNewBtn = driver.FindElement(By.XPath("//a[@class='btn btn-primary']"));
        createNewBtn.Click();

        // select from time from description
        IWebElement typeCodeDropDown = driver.FindElement(By.XPath("//span[@class='k-input']"));
        typeCodeDropDown.Click();

        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timeOption.Click();

        // type code into code txtbox
        IWebElement codeTxt = driver.FindElement(By.Id("Code"));
        codeTxt.SendKeys("TA Programme March");

        // type description into description txtbox
        IWebElement descriptinTxt = driver.FindElement(By.Id("Description"));
        descriptinTxt.SendKeys("Description March");

        // type price into price txtbox
        IWebElement priceTagOverLap = driver.FindElement(By.XPath("//input[@class='k-formatted-value k-input']"));
        priceTagOverLap.Click();

        IWebElement priceTxt = driver.FindElement(By.Id("Price"));
        priceTxt.SendKeys("120");
        
        // click on save btn
        IWebElement saveBtn = driver.FindElement(By.Id("SaveButton"));
        saveBtn.Click();
        Thread.Sleep(3000);

        // check if time record has been created sucessfully
        IWebElement goToLastPageButton = driver.FindElement(By.XPath("//span[@class='k-icon k-i-seek-e']"));
        goToLastPageButton.Click();

        IWebElement findLastCodeRecord = driver.FindElement(By.XPath("//tbody/tr[last()]/td[1]"));

        if(findLastCodeRecord.Text == "TA Programme March")
        {
            Console.WriteLine("New Time & Material Record has been created successfully.");
        }
        else
        {
            Console.WriteLine("Time & Material Record has not been created ");
        }
    }
}