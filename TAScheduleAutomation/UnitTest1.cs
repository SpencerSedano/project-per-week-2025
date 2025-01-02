using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TAScheduleAutomation;

public class Tests {
    private IWebDriver driver;
    
    [SetUp]
    public void Setup() {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void Test1() {
        driver.Navigate().GoToUrl("https://tdcenter.pu.edu.tw/p/405-1061-13442,c2707.php?Lang=zh-tw");
        Assert.That(driver.Url, Is.EqualTo("https://tdcenter.pu.edu.tw/p/405-1061-13442,c2707.php?Lang=zh-tw"));
    }

    [TearDown]
    public void TearDown() {
        driver?.Quit();
        driver?.Dispose();
    }


}