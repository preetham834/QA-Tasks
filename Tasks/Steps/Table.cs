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

[Binding]
public class TableTest
{
    private WebTables tab;
    private IPage page;
    public TableTest(ScenarioContext scenario)
    {
        page = (IPage)scenario["PAGE"];
    }
    [When("I add record {string} {string} {string} {string} {string} {string}")]
    public async Task WhenIAddRecord(string first,string last, string email,string age,string salary,string dept)
    {
        tab = new WebTables(page);

        await tab.AddRecord(WebTableMap.tablelocators["firstname"], first);
        await tab.AddRecord(WebTableMap.tablelocators["lastname"], last);
        await tab.AddRecord(WebTableMap.tablelocators["email"], email);
        await tab.AddRecord(WebTableMap.tablelocators["age"], age);
        await tab.AddRecord(WebTableMap.tablelocators["salary"], salary);
        await tab.AddRecord(WebTableMap.tablelocators["department"], dept);
    }
}