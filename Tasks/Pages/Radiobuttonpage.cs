using Microsoft.Playwright;
using NUnit;
using buttonnnss;
namespace pages;

public class Radiobutton
{
    private IPage page;
    public Radiobutton(IPage page)
    {
        this.page = page;
    }
    public async Task Radioselect(String buttonname)
    {
        var loc = ButtonMap.buttons[buttonname];

        await page.Locator(loc).CheckAsync();
    }
    public async Task RadioUnselect(string buttonname)
    {
        await page.Locator(buttonname).UncheckAsync();
    }
   

}