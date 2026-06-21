using Microsoft.Playwright;
using Allure.NUnit;
using NUnit;
using Reqnroll;
using static Microsoft.Playwright.Assertions;
using Commons;
using Locators;
//using Url;

using pages;

[AllureNUnit]  
[Binding]
public class Text
{   
    private TextBox textbox;
    private IPage page;
    public Text(ScenarioContext scenario)
    {
        page = (IPage)scenario["PAGE"];
    }
    [Then("I should see {string} in {string}")]
   public async Task ThenIShouldSeeInField(string expectedValue, string field)
   {
    textbox=new TextBox(page);
    var locator=FieldMap.Fields[field];
    await textbox.VerifyText(locator,expectedValue);
   
   }
}

