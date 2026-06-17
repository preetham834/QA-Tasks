using NUnit;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using Reqnroll;
using pages;
using buttonnnss;

[Binding]
public class Checkboxtest:Baseclass
{
    private Checkbox check;
    [When("I select {string} checkbox")]
    public async Task Check(string buttoname)
    {
        check = new Checkbox(page);
        var loc = ButtonMap.buttons[buttoname];
        await check.Select(loc);
        await Expect(page.Locator(loc)).ToBeCheckedAsync();
    }
    [When("I unselect {string} checkbox")]
    public async Task UnCheck(string buttoname)
    {
        check = new Checkbox(page);
        var loc = ButtonMap.buttons[buttoname];
        await check.Unselect(loc);
        await Expect(page.Locator(loc)).Not.ToBeCheckedAsync();
    }
    

}