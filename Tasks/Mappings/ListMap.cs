using Microsoft.Playwright;
using NUnit;
namespace itemss;
public class SortableMap
{
    public static Dictionary<string,string> items=new()
    {
        { "One", ".vertical-list-container >> text=One" },
        { "Two", ".vertical-list-container >> text=Two" },
        { "Three", ".vertical-list-container >> text=Three" },
        { "Four", ".vertical-list-container >> text=Four" },
        { "Five", ".vertical-list-container >> text=Five" },
        { "Six", ".vertical-list-container >> text=Six" }
    };
}