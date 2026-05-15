using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System.Threading;

namespace TestProject.Pages;


public class QATestPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;



    public QATestPage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    }

    //grabbing elements to refer to later

    private IWebElement AcceptCookies => wait.Until(x => x.FindElement(By.CssSelector("#CybotCookiebotDialogBodyButtonAccept")));



    private IWebElement MagnifyingGlass =>
    wait.Until(x => x.FindElement(By.CssSelector("form button.header__newSearch.header__button")));
    private IWebElement SearchBar =>
    wait.Until(x => x.FindElement(By.CssSelector("input[name='search']")));

    public void GoTo()
    {
        driver.Navigate().GoToUrl("https://www.qa.com/");
    }

    public void AutoAcceptCookies()
    {
        AcceptCookies.Click();
    }

    public void AutoSearch(String searchString)
    {
        MagnifyingGlass.Click();
        SearchBar.SendKeys(searchString + Keys.Enter);
    }

    public void Holup(int ms)
    {
        Thread.Sleep(ms);
    }

}