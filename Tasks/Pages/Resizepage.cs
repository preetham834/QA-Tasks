using Microsoft.Playwright;
using NUnit;
using buttonnnss;
namespace pages;

public class Resize
{
    private IPage page;

    private float initialWidth;
    private float initialHeight;
    public Resize(IPage page)
    {
        this.page = page;
    }
    public async Task ResizeBox()
    {
        var box = page.Locator("#resizableBoxWithRestriction");
        var box1 = await box.BoundingBoxAsync();

        initialWidth = box1.Width;
        initialHeight = box1.Height;

        float startX = box1.X + box1.Width - 5;
        float startY = box1.Y + box1.Height - 5;

        await page.Mouse.MoveAsync(startX, startY);
        await page.Mouse.DownAsync();
        //await page.Mouse.MoveAsync(startX + 5, startY + 5);

        await page.Mouse.MoveAsync(
               startX + 50,
               startY + 60,
               new MouseMoveOptions { Steps = 15 }
           );

        await page.Mouse.UpAsync();
    }

    public async Task ValidateBox()
    {
        var box = page.Locator("#resizableBoxWithRestriction");
        var box2 = await box.BoundingBoxAsync();
        Assert.That(box2.Width, Is.GreaterThan(initialWidth));
        Assert.That(box2.Width, Is.GreaterThan(initialWidth));
    }
}