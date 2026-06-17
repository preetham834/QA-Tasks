using Microsoft.Playwright;
using NUnit.Framework;
using Reqnroll;
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(0)]
public abstract class Baseclass
{
    protected static IPlaywright playwright = null!;
    protected static IBrowser browser = null!;
    protected static IBrowserContext context = null!;
    protected static IPage page = null!;
    // private readonly AllureHelper helper;
    protected int Retrycount = 3;
    [BeforeScenario]
    public async Task Setup()
    {

        if (page != null && !page.IsClosed)
        {
            Console.WriteLine("Setup already executed, skipping...");
            return;
        }

        playwright = await Playwright.CreateAsync();
        browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
             SlowMo=1000
        });

        context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            RecordVideoDir = "videos"
        });
        await context.Tracing.StartAsync(new()
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        page = await context.NewPageAsync();
    }
    [AfterScenario]
    public async Task Teardown(ScenarioContext scenario)
    {

        if (page == null && context == null && browser == null)
        {
            return;
        }

        string scenarioName = scenario.ScenarioInfo.Title;

        var debug = new Debugger(page);
        var video = page?.Video;

        try
        {
            if (context != null)
            {
                if (scenario.TestError != null)
                {
                    await context.Tracing.StopAsync(new() { Path = "trace.zip" });

                    if (page != null)
                    {
                        await debug.CaptureScreenshot(scenarioName);
                        await debug.CaptureLog(scenarioName, scenario.TestError.Message);
                    }
                }
                else
                {
                    await context.Tracing.StopAsync();
                }
            }
            if (page != null && !page.IsClosed)
            {
                await page.CloseAsync();
            }
            if (context != null)
            {
                await context.CloseAsync();
            }
            await Task.Delay(300); 
            if (scenario.TestError != null && video != null)
            {
                await video.SaveAsAsync($"videos/{scenarioName}.webm");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Teardown warning: {ex.Message}");
        }
        finally
        {
            try
            {
                if (browser != null)
                {
                    await browser.CloseAsync();
                }
            }
            catch { }

            try
            {
                playwright?.Dispose();
            }
            catch { }

            Console.WriteLine(" Teardown completed safely");
        }
    }
}