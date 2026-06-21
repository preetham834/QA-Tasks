using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using NUnit;
using pages;
using Locators;
using Reqnroll;
using buttonnnss;
[Binding]
public class FileTest
{
    private IPage page;
    public FileTest(ScenarioContext scenario)
    {
        page = (IPage)scenario["PAGE"];
    }
    private string downloadPath;
    [When("I upload {string} file in {string}")]
    public async Task Upload(string filename,string field)
    {
        var loc = ButtonMap.buttons[field];
        await page.Locator(loc).SetInputFilesAsync(filename);
    }
    [When("I download using {string} button")]
     public async Task Download(string buttoname)
    {
        var loc = ButtonMap.buttons[buttoname];
        var download = await page.RunAndWaitForDownloadAsync(async () =>
        {
            await page.Locator(loc).ClickAsync();
        });
        downloadPath =Path.Combine(Directory.GetCurrentDirectory(),"Downloads",
        download.SuggestedFilename);

        await download.SaveAsAsync(downloadPath);
    }

    [Then("File exists locally")]
    public async Task DownloadValidation()
    {
        Assert.That(File.Exists(downloadPath), Is.True);
    }

}