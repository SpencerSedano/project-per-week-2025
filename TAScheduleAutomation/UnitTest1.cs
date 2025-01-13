using Microsoft.Playwright;

namespace TAScheduleAutomation;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test()
    {
        EnvReader.Load("/Users/spencersedano/Desktop/2025 Coding Resolution/TAScheduleAutomation/.env");

        string? systemPassword = Environment.GetEnvironmentVariable("SYSTEM_PASSWORD");

        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://ta.pu.edu.tw/login.php");
        await page.Locator("#rt_01").FillAsync("s1111067");
        await page.Locator("#rt_02").FillAsync(systemPassword);
        await page.Locator(".btn-primary").ClickAsync();

        //Delays after login because page needs to load
        await Task.Delay(5000);
        await page.Locator("#mB").HoverAsync();
        await page.Locator("#navMenu2").HoverAsync();
        //Delays after hovering because menu button is hidden
        //It needs to hover to show up
        await Task.Delay(5000);
        await page.Locator("#dropMenu2").ClickAsync();
        //Delays after clicking menu because page needs to load
        await Task.Delay(10000);
        
        //Finally, enter to schedule
        await page.GetByText("預覽").FocusAsync();
        await page.GetByText("預覽").ClickAsync();
        await Task.Delay(5000);
    }
}