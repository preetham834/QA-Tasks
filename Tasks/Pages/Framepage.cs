using Microsoft.Playwright;
using NUnit;
using static Microsoft.Playwright.Assertions;
namespace pages;

public class Frames
{
    private IPage page;
    public Frames(IPage page)
    {
        this.page = page;
    }
    public async Task FrameHandling(string field,string result)
    {
        var element=page.FrameLocator(field).Locator("#sampleHeading");

        await Expect(element).ToHaveTextAsync(result);
    }
    public async Task NFrameHandling(string field, string result)
    {
        var element = page.FrameLocator(field).Locator("body");

        await Expect(element).ToContainTextAsync(result);
        

    }

}