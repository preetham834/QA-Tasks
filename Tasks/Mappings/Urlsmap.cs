using Microsoft.Playwright;
using NUnit;
namespace Urls;
public class UrlMap
{
    public static Dictionary<String,String> urls=new()
    {
        {"textbox","https://demoqa.com/text-box"},
        {"checkbox","https://demoqa.com/checkbox"},
        {"radio","https://demoqa.com/radio-button"},
        {"buttons","https://demoqa.com/buttons"},
        {"tables","https://demoqa.com/webtables"},
        {"dialogs","https://demoqa.com/modal-dialogs"},
        {"alerts","https://demoqa.com/alerts"},
        {"browser","https://demoqa.com/browser-windows" },
        {"Frames","https://demoqa.com/frames" },
        {"Nestedframes","https://demoqa.com/nestedframes" },
        {"upload","https://demoqa.com/upload-download" },
        {"sortable","https://demoqa.com/sortable" },
        {"Resize","https://demoqa.com/resizable" }
        
    };
}