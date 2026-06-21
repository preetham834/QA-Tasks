using Microsoft.Playwright;
using NUnit;
using static Microsoft.Playwright.Assertions;
using Reqnroll;
using pages;
using Locators;
using Urls;
using buttonnnss;
using itemss;
[Binding]
public class SortTest
{

    private IReadOnlyList<string> beforeOrder;
    private Sortable sort;
    private IPage page;
    public SortTest(ScenarioContext scenario)
    {
        page = (IPage)scenario["PAGE"];
    }

    [When("I reorder {string} to {string}")]
        public async Task WhenIReorder(string source, string dest)
        {
        beforeOrder = await page.Locator(".vertical-list-container .list-group-item").AllTextContentsAsync();
        var sort = new Sortable(page);
        await sort.Reorder(source, dest);
        }

        [Then("items should be reordered")]
        public async Task ValidateOrder()
        {
        var items = page.Locator(".vertical-list-container .list-group-item");
        var afterOrder = await items.AllTextContentsAsync();
         Assert.That(afterOrder, Is.Not.EqualTo(beforeOrder),
                "List order did not change");

    }

}