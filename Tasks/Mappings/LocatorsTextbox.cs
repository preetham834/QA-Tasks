using NUnit;
using Microsoft.Playwright;
namespace Locators;

public class FieldMap
{
public static Dictionary<string, string> Fields = new()
{
    { "name", "#userName" },
    { "email", "#userEmail" },
    {"current address","#currentAddress"},
    {"permanent address","#permanentAddress"},
    {"outputname","#name"}
};
}
