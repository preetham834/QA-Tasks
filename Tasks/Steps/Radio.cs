using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using NUnit;
using Reqnroll;
using pages;
using buttonnnss;
[Binding]
public class Radiotest
{
	private Radiobutton radio;
    private IPage page;
    public Radiotest(ScenarioContext scenario)
    {
        page = (IPage)scenario["PAGE"];
    }
    [When("I select {string} radio button")]
	public async Task Radio(string buttonname)
	{
		radio = new Radiobutton(page);
		await radio.Radioselect(buttonname);
	}
	[Then("{string} radio button is selected")]
	public async Task RadioValidation(string buttonname)
	{
		var loc = ButtonMap.buttons[buttonname];
		await Expect(page.Locator(loc)).ToBeCheckedAsync();
	}
	[Then("{string} radio button is unselected")]
	public async Task RadioValidation1(string buttonname)
	{
		var loc = ButtonMap.buttons[buttonname];
		await Expect(page.Locator(loc)).Not.ToBeCheckedAsync();
	}
	[Then("{string} radio button is disabled")]
	public async Task IsDisabled(string buttonname)
	{
		var loc = ButtonMap.buttons[buttonname];
		await Expect(page.Locator(loc)).ToBeDisabledAsync();
	}

}

