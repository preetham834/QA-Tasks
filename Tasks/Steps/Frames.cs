using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using NUnit;
using Reqnroll;
using pages;
using buttonnnss;
[Binding]
public class FrameTest
{
    private Frames frame;
    private IPage page;
    public FrameTest(ScenarioContext scenario)
    {
        page = (IPage)scenario["PAGE"];
    }
    [Then("I should see {string} in frame {string}")]
    public async Task FrameValidation(string expected,string field)
    {
        frame = new Frames(page);
        var loc = ButtonMap.buttons[field];
        await frame.FrameHandling(loc, expected);
    }
    [Then("I should see {string} in Nframe {string}")]
    public async Task NFrameValidation(string expected, string field)
    {
        frame = new Frames(page);
        var loc = ButtonMap.buttons[field];
        await frame.NFrameHandling(loc, expected);
    }
    [Then("I should see {string} in {string} which is in {string}")]
    public async Task ChildValidation(string expected,string field1,string field2)
    {
        frame = new Frames(page);
        var loc1 = ButtonMap.buttons[field1];
        var loc2= ButtonMap.buttons[field2];
        var elemt = page.FrameLocator(loc2).FrameLocator(loc1).Locator("p");
        await Expect(elemt).ToContainTextAsync(expected);
    }

}