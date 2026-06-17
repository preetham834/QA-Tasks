using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using NUnit;
using Reqnroll;
using Urls;
using pages;

[Binding]
public class ResizeTest:Baseclass
{

    private Resize resize;
    [When("I Resize the box")]
    public async Task Resize()
    {
        var resize = new Resize(page);
        await resize.ResizeBox();
    }
    [Then("Box should be resized")]
    public async Task ValidateBox()
    {
        var resize = new Resize(page);
        await resize.ValidateBox();


    }
}