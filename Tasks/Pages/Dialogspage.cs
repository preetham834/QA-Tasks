using Microsoft.Playwright;
using NUnit;
namespace pages;
public class Dialog
{
    private IPage page;
    private Autohelper helper;

    public Dialog(IPage page)
    {
        this.page = page;
        helper = new Autohelper(page);

    }
    public async Task Modals(string locator)
    {


        Console.WriteLine("Entering Modals method");

        await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

        Console.WriteLine("Before Title");

        var title = await page.TitleAsync();
        Console.WriteLine($"Page Title: {title}");

        if (await page.Locator("text=This page has been blocked").IsVisibleAsync())
        {
            throw new Exception(" Site blocked");
        }

        var ele = page.Locator(locator);
        //  await ele.WaitForAsync(new() { Timeout = 60000 });
        //await ele.ScrollIntoViewIfNeededAsync();
        await ele.ClickAsync();
        Console.WriteLine(" Modal click successful");

    }
}