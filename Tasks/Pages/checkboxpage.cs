using Microsoft.Playwright;
using NUnit;
public class Checkbox
{
    private IPage page;
    public Checkbox(IPage page)
    {
        this.page = page;
    }
    public async Task Select(string buttonname)
    {
        await page.Locator(buttonname).CheckAsync();
    }
    public async Task Unselect(string buttonname)
    {
        await page.Locator("button").UncheckAsync();
    }

}