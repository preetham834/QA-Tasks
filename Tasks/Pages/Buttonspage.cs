using NUnit;
using Microsoft.Playwright;
using buttonnnss;
namespace pages;
 public class Button
 {
    private readonly IPage page;
    public Button(IPage page)
    {
        this.page=page;
    }
    public async Task Clicks(string button,string selector)//dbclick,#doubleClickBtn
    {
        var element=  page.Locator(selector);
        
        switch(button)
        {
            case "dbclick": 
            {
                Console.WriteLine(element+" "+button+" "+selector);
                await element.DblClickAsync();
               // {
                 //   Force=true
                //});
                break;
            }
            case "rightclick":  
            {
                await element.ClickAsync(new LocatorClickOptions
                {
                Button = MouseButton.Right
                });
                break;
            }
            case "singleclick":
            {
               await element.Nth(2).ClickAsync(); break;
            }
            case"add":
            {
                await element.ClickAsync();
                break;
            }
        }

    }
    public async Task Click(string buttonname)
    {
       // var loc = ButtonMap.buttons[button]
        await page.Locator(buttonname).ClickAsync();
  
    }
 }