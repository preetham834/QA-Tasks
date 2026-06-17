using Microsoft.Playwright;
using NUnit;
using static Microsoft.Playwright.Assertions;
using Commons;
using Locators;
namespace pages;
public class TextBox
{
    //private readonly CommonSteps common;
   
     private readonly IPage page;

    public TextBox(IPage page)
    {
        this.page = page;
    }

     public async Task EnterValue(String locator,String value)
    {
         var element=page.Locator(locator);

       // await element.WaitForAsync(new() { State = WaitForSelectorState.Visible });

        await element.ClickAsync();
       // await element.FillAsync("");
        await element.FillAsync(value);
        await page.Locator("body").ClickAsync();

    }

    public async Task VerifyText(string locator, string expectedValue)
    { 

        Console.WriteLine($"Locator = {locator}");
        Console.WriteLine($"Expected = {expectedValue}");
        var element = page.Locator(locator);
        //await element.WaitForAsync();
        element.ScrollIntoViewIfNeededAsync();
        Console.WriteLine(await element.TextContentAsync() );
        Expect(element).ToContainTextAsync(expectedValue);
    }

}