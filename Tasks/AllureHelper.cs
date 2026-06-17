using Allure.Commons;
using System.Text;
using System.IO;

using Microsoft.Playwright;
 public class AllureHelper
 {
    private readonly IPage page;

    public AllureHelper(IPage page)
    {
        this.page=page;
    }

    public async Task CaptureScreenshot(string name)
    {
        try {
            var bytes = await page.ScreenshotAsync(new()
            {
                FullPage = true
            });

            AllureLifecycle.Instance.AddAttachment(
                $"{name}.png",
                "image/png",
                bytes
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Trace failed: {ex.Message}");
        }
    }
    public void AttachLog(String message)
    {
        try
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            AllureLifecycle.Instance.AddAttachment(
                "Log", "text/plain", bytes, ".txt"
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Log failed: {ex.Message}");
        }
    }
    public async Task AttachTrace(String tracePath)
    {
        try
        {

            var bytes = await File.ReadAllBytesAsync(tracePath);
            AllureLifecycle.Instance.AddAttachment(
                "Trace",
                "application/zip",
                bytes, ".zip"
            );
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Screenshot failed: {ex.Message}");

        }
    }

 }