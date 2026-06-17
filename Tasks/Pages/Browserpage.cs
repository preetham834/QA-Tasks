using Microsoft.Playwright;
using NUnit;
using static Microsoft.Playwright.Assertions;
namespace pages;

public class BrowserPage
{
    private IPage page;
    private IPage newtab;
    public BrowserPage(IPage page)
    {
        this.page = page;
    }
    public async Task<IPage> Multitab(string buttonname)
    {
        var popup = page.WaitForPopupAsync();
        await page.Locator(buttonname).ClickAsync();
        newtab = await popup;
        await Expect(newtab.Locator("#sampleHeading")).ToHaveTextAsync("This is a sample page");
        await page.BringToFrontAsync();
       return newtab;
    }
}