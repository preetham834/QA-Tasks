using Microsoft.Playwright;
using NUnit;
using static Microsoft.Playwright.Assertions;

public class Autohelper
{
    private IPage page;
    public Autohelper(IPage page)
    {
        this.page = page;
    }
    public async Task WaitForElement(string locator)
    {
        await page.Locator(locator).WaitForAsync(new()
        {
            State = WaitForSelectorState.Visible

        });
        await page.Locator(locator).WaitForAsync(new()
        {
            State = WaitForSelectorState.Attached
        });
    }
    public async Task WaitForClickable(string locator)
    {
        await page.Locator(locator).WaitForAsync(new()
        {
            State = WaitForSelectorState.Visible
        });
        await Expect(page.Locator(locator)).ToBeEnabledAsync();

    }
    public async Task Retry(Func<Task>action, int retry)
    {
        for(int i=1;i<=retry;i++)
        {
            try
            {
                await action();
                return;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Retry {i} failed:{ex.Message}");
                if (i == retry)
                    return;
            }
        }
    }

        

    }