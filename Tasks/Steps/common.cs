using Microsoft.Playwright;
using Allure.NUnit;
using Allure.Commons;
using NUnit;
using Reqnroll;
using static Microsoft.Playwright.Assertions;
using Locators;
using Config;
using pages;
using Urls;
using buttonnnss;
using Reqnroll.Formatters.PubSub;
namespace Commons;

[Binding]
public class CommonSteps : Baseclass
{

    private TextBox textbox;
    private Button? button;
    private WebTables tab;
    private Autohelper auto;
    private Frames frame;
    private BrowserPage browser;

    // private ConfigReader Reader;

    //  private readonly IPage page;

    /*public CommonSteps(IPage page)
    {
        this.page=page;
    }*/

    public async Task Navigate(String url)
    {
        await page.GotoAsync(url);
        // await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        Console.WriteLine($"After navigation: {page.Url}");

    }

    [Given("I navigates to {string} page")]
    public async Task GivenINaviagates(String pagename)
    {
        //var reader = new ConfigReader();

        //if (!reader.ShouldRun(pagename))
        //    Assert.Ignore("Not valid for current environment");
        //var url = reader.GetUrl(pagename);
        var url = UrlMap.urls[pagename];
        await Navigate(url);
    }


    [When("I enter {string} as {string}")]
    public async Task WhenIEnter(string value, string field)
    {
        textbox = new TextBox(page);
        var locator = FieldMap.Fields[field];
        await textbox.EnterValue(locator, value);
    }
    [When("I click on {string} button")] //dbclick
    public async Task WhenIclickon(string buttonName)
    {
        var but = ButtonMap.buttons[buttonName];
        button = new Button(page);
        await button.Click(but);
    }
    [When("I click on {string} buttons")] //dbclick
    public async Task WhenIclickona(string buttonName)
    {
        var but = ButtonMap.buttons[buttonName];
        button = new Button(page);
        await button.Clicks(buttonName,but);
    }
    [When("I add records {string} as {string}")]
    public async Task WhenIadd(string value, string field)
    {
        var t = WebTableMap.tablelocators[field];
        tab = new WebTables(page);
        await tab.AddRecord(t, value);
    }
    [When("I edit record {string} as {string}")]
    public async Task WhenIEdit(string value, string field)
    {
        var t= WebTableMap.tablelocators[field];
        tab = new WebTables(page);
        await tab.Edit(t, value);
    }
    [Then("I should see {string} in table {string}")]
    public async Task ThenIShouldSeeInTable(string expectedValue, string wt)
    {
        var auto = new Autohelper(page);
        var locator = WebTableMap.tablelocators[wt];
        string actualText = "";
        tab = new WebTables(page);
        await auto.Retry(async () =>
        {

            actualText = await tab.GetTableText(locator);
            if (!actualText.Contains(expectedValue))
            {
                throw new Exception("Not found");
            }

        }, 4);
        Console.WriteLine($"EXPECTED: {expectedValue}");
        Console.WriteLine($"ACTUAL: {actualText}");
        Assert.That(actualText, Does.Contain(expectedValue),
            $"Expected {expectedValue} not found in table");
    }

    [When("I click on alert popping {string} button")]
    public async Task Alerthandling(string buttonname)
    {
        var but = ButtonMap.buttons[buttonname];
        EventHandler<IDialog>? handler = null;
        handler = async (_, dialog) =>
        {
            await dialog.AcceptAsync();
            page.Dialog -= handler;
        };

        page.Dialog += handler;
        await page.Locator(but).ClickAsync();
    }

    [Then("I should see {string} in {string} area")]
    public async Task Verifyresult(string result, string field)
    {
        var button = new Button(page);
        var loc = ButtonMap.buttons[field];
        await Expect(page.Locator(loc)).ToContainTextAsync(result);
    }
    [When("I click on {string} multitab button")]
    public async Task Multi(string buttonname)
    {
        browser = new BrowserPage(page);
        var loc = ButtonMap.buttons[buttonname];
        await browser.Multitab(loc);

    }
    [When("I search {string} in {string} bar")]
    public async Task WhenIsearch(string value, string field)
    {
        var locator = WebTableMap.tablelocators[field];
        tab = new WebTables(page);
        await tab.SearchRecord(locator, value);

    }
    [Then("I should see no result in {string}")]
    public async Task ValidateNull(string field)
    {
        tab=new WebTables(page);
        var loc = WebTableMap.tablelocators[field];
        await Expect(page.Locator(loc)).ToBeEmptyAsync();
    }

}
