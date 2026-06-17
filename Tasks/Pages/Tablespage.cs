using Microsoft.Playwright;
using NUnit;
using static Microsoft.Playwright.Assertions;
namespace pages;

public class WebTables
{
    private IPage page;
    private Autohelper auto;

    public WebTables(IPage page)
    {
        this.page=page;
        auto = new Autohelper(page);
    }

    public async Task AddRecord(string locator,string value)
    {
        var element = page.Locator(locator);
        await auto.Retry(async () =>
        {
            await auto.WaitForElement(locator);
            Console.WriteLine(element);
            await element.FillAsync(value);
        }, 3);

    }
    public async Task SearchRecord(string locator,string value)
    {
        var ele = page.Locator(locator);
        await ele.FillAsync(value);
    }


    public async Task<string> GetTableText(string tableLocator)
    {
        var table = page.Locator(tableLocator);
        String result = "";
        await auto.Retry(async () =>
        {
            await auto.WaitForElement(tableLocator);
            result = await table.InnerTextAsync();
        }, 3);
        return result;
    }
    public async Task Edit(string locator, string value)
    {
        var element = page.Locator(locator);
       // await auto.WaitForElement(locator);
       // Console.WriteLine(element);
        await element.FillAsync(value);

    }


}