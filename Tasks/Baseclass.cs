using Microsoft.Playwright;
using Reqnroll;
using Logs;


[assembly: Parallelizable(ParallelScope.All)]
[assembly: LevelOfParallelism(14)]


[Binding]
public class Baseclass
{
    private static IPlaywright playwright;
    private static IBrowser browser;
    private Debugger debug;

    [BeforeTestRun]
    public static async Task GlobalSetup()
    {
        playwright = await Playwright.CreateAsync();

        browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        Console.WriteLine(" Single browser instance is created");
    }

    [BeforeScenario]
    public async Task Setup(ScenarioContext scenario)
    {

        var context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            RecordVideoDir = "videos"
        });
        await context.Tracing.StartAsync(new()
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        var page = await context.NewPageAsync();
        scenario["CONTEXT"] = context;
        scenario["PAGE"] = page;

        Console.WriteLine("Scenario started");
    }

    [AfterScenario]
    public async Task TearDown(ScenarioContext scenario)
    {
        string s1 = scenario.ScenarioInfo.Title;
        var context = (IBrowserContext)scenario["CONTEXT"];
        var page = (IPage)scenario["PAGE"];
        var debug = new Debugger(page);
        var video = page?.Video;
        if (!scenario.ContainsKey("CONTEXT"))
            return;
        if (scenario.TestError != null)
        {
            await context.Tracing.StopAsync(new() { Path = "trace.zip" });
            await debug.CaptureScreenshot(s1);
            await debug.CaptureLog(s1, scenario.TestError.Message);
        }
        else
        {
            await context.Tracing.StopAsync();
        }

        await page.CloseAsync();
        await context.CloseAsync();

        if (scenario.TestError != null && video != null)
        {
            await video.SaveAsAsync($"videos/{s1}.webm");
        }
        Console.WriteLine($"Scenario completed");
    }

    [AfterTestRun]
    public static async Task Cleanup()
    {
        await browser.CloseAsync();
        playwright.Dispose();

        Console.WriteLine(" Browser is closed and playwright is disposed");
        Console.WriteLine(" Browser is closed");
    }
}