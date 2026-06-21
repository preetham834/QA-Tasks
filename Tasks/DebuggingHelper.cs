using Microsoft.Playwright;
using NUnit;
namespace Logs;
public class Debugger
{
    private IPage page;
    public Debugger(IPage page)
    {
        this.page = page;
    }
    public async Task CaptureScreenshot(String scenarioName)
    {
        Directory.CreateDirectory("Screenshots");
        string path = Path.Combine("Screenshots", $"S{scenarioName}--{DateTime.Now:yyyy_MM_dd}-{Guid.NewGuid()}.png");
        await page.ScreenshotAsync(new()
        {
            Path = path,
            FullPage = true
        });
        Console.WriteLine($"Screenshot captureed on failure:{path}");
    }

    public async Task CaptureLog(String scenarioName, string message)
    {
        Directory.CreateDirectory("Logs");
        string path = Path.Combine("Logs", $"{scenarioName}-{DateTime.Now:yyyy_MM_dd}-{Guid.NewGuid()}.txt");
        await File.WriteAllTextAsync(path, message);
        Console.WriteLine($"Log saved:{path}");
    }
    public async Task CaptureVideo(string scenarioName,IVideo video)
    {
        Directory.CreateDirectory("videos");
        string videopath = await video.PathAsync();
        string path = Path.Combine("videos", $"{scenarioName}-{DateTime.Now:yyyy_MM_dd}-{Guid.NewGuid()}.webm");
        File.Move(videopath, path);
        Console.WriteLine($"video captured on failure:{path}");


       
    }

}