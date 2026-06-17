using Microsoft.Extensions.Configuration;
namespace Config;
public class ConfigReader
{
    private IConfiguration config;

   public ConfigReader()
    {
    config = new ConfigurationBuilder().AddJsonFile("settings.json").Build();
    }
    public string GetUrl(string pageName)
    {
        var env = config["Environment"];//DEV
        return config[$"Environments:{env}:{pageName}"];//urls
    }

    //public bool ShouldRun(string pageName)
    //{
    //    var env = config["Environment"];
    //    var allowedPage = config[$"Environments:{env}"]
    //                        .Split('/')
    //                        .Last()
    //                        .ToLower();

    //    return pageName.ToLower() == allowedPage;
    //}


}