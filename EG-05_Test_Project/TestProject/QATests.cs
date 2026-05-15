using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject.Pages;

public class Program
{

    public static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();

        QATestPage page = new QATestPage(driver);

        page.GoTo(); //the link has been moved to the POM class
        page.AutoAcceptCookies();
        page.AutoSearch("java");

        page.Holup(5000);


        driver.Quit();
    }


}
