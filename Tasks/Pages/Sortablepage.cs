using Microsoft.Playwright;
using NUnit;
using itemss;
namespace pages;

public class Sortable
{
    private IPage page;
    public Sortable(IPage page)
    {
        this.page = page;
    }
    public async Task Reorder(string source,string dest)
    {

        var sourceElement = page.Locator(SortableMap.items[source]);
        var destElement = page.Locator(SortableMap.items[dest]);

        var box1 = await sourceElement.BoundingBoxAsync();
        var box2 = await destElement.BoundingBoxAsync();
        await page.Mouse.MoveAsync(
            box1.X + box1.Width / 2 + 10,
            box1.Y + box1.Height / 2 + 10
        );

        await page.Mouse.DownAsync();

        await page.WaitForTimeoutAsync(800);

        await page.Mouse.MoveAsync(
            box1.X + box1.Width / 2 + 10,
            box1.Y + box1.Height / 2 + 10,
            new MouseMoveOptions { Steps = 5 }
        );
        await page.WaitForTimeoutAsync(600);

        await page.Mouse.MoveAsync(
            box1.X + box1.Width / 2,
            (box1.Y + box2.Y) / 2,
            new MouseMoveOptions { Steps = 20 }
        );


        await page.Mouse.MoveAsync(
            box2.X + box2.Width / 2,
            box2.Y + box2.Height / 2 + 10,
            new MouseMoveOptions { Steps = 25 });

        await page.Mouse.UpAsync();
    }
}