using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using NUnit;
using Reqnroll;
using Urls;
using pages;

[Binding]
public class ResizeTest
{

    private Resize resize;
    private IPage page;
    public ResizeTest(ScenarioContext scenario)
    {
        page = (IPage)scenario["PAGE"];
    }
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