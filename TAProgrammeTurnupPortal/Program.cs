using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TAProgrammeTurnupPortalNew.Pages;

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

        //Login page object initialization
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(driver);

        //Home page object initialization
        HomePage homePageObj = new HomePage();
        homePageObj.NavigateToTMPage(driver);

        //Time & Material page object initialization
        TMPage tmPageObj = new TMPage();
        tmPageObj.CreateNewTimeAndMaterialRecord(driver);

        tmPageObj.EditTimeAndMaterialRecord(driver);

        tmPageObj.DeleteTimeAndMaterialRecord(driver);
    }
}
