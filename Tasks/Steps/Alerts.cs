using Microsoft.Playwright;
using NUnit;
using static Microsoft.Playwright.Assertions;
using Reqnroll;
using pages;
using Locators;
using Urls;
using buttonnnss;

[Binding]
public class AlertTest : Baseclass
{

    private string randomValue;

    [When("I click on Prompt {string} button")]
    public async Task PAlerthandling(string buttonname)
    {
         randomValue = $"Test_{Guid.NewGuid().ToString().Substring(0, 5)}";
        var but = ButtonMap.buttons[buttonname];
        EventHandler<IDialog>? handler = null;
        handler = async (_, dialog) =>
        {
            await dialog.AcceptAsync(randomValue);
            page.Dialog -= handler;
        };

        page.Dialog += handler;
        await page.Locator(but).ClickAsync();

    }

    [Then("I should see entered value in prompt area")]
    public async Task ThenIValidateValue()
    {
        await Expect(page.Locator("#promptResult"))
            .ToHaveTextAsync($"You entered {randomValue}");
    }
}