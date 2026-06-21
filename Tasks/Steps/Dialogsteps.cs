using Microsoft.Playwright;
using NUnit;
using Allure.NUnit;
using Allure.Commons;
using Reqnroll;
using buttonnnss;
using pages;
using static Microsoft.Playwright.Assertions;
using CsvHelper;

[Binding]
public class ModalTest
{
    private Dialog dialog;
    private Button button;
    private IPage page;
    public ModalTest(ScenarioContext scenario)
    {
        page = (IPage)scenario["PAGE"];
    }
    [When("I click on dialog {string} button")]
    public async Task WhenIClickonDialogbuttons(string buttonName)
    {
        var butt = ButtonMap.buttons[buttonName];
        Console.WriteLine(butt);
        dialog = new Dialog(page);
        await dialog.Modals(butt);

    }
    [Then("{string} should contain text {string}")]
    public async Task ValidateText(string field,string expected)
    {
        var butt = ButtonMap.buttons[field];
        await Expect(page.Locator(butt)).ToContainTextAsync(expected);

    }
}