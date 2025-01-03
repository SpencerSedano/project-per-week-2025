using Microsoft.Playwright;

namespace TAScheduleAutomation;

public class Tests {
    [SetUp]
    public void Setup() {

    }

    [Test]
    public async Task Test() {
        EnvReader.Load("/Users/spencersedano/Desktop/2025 Coding Resolution/TAScheduleAutomation/.env");
        
        string? systemPassword = Environment.GetEnvironmentVariable("SYSTEM_PASSWORD");
        
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions {
            Headless = false,
        });
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://ta.pu.edu.tw/login.php");
        await page.Locator("#rt_01").FillAsync("s1111067");
        await page.Locator("#rt_02").FillAsync(systemPassword);
        await page.Locator(".btn-primary").ClickAsync();
        await Task.Delay(5000);


    }
}