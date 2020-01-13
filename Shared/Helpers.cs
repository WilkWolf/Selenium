using OpenQA.Selenium.Chrome;
using System.IO;
using Newtonsoft.Json.Linq;

namespace SeleniumApplication.Shared
{
    static class  Helpers
    {
        public static ChromeDriver RunPage(string pageUrl)
        {
            string url = GetPage(pageUrl);
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            return driver;
        }

        private static string GetPage(string page)
        {
           return  Configuration.BaseUrl + page;
        }

        public static string GetValueFromSettings(string jsonPath)
        {
            string jsonSettingsFile = File.ReadAllText("Settings.json");
            JObject settingsObject = JObject.Parse(jsonSettingsFile);
            string value = (string)settingsObject.SelectToken(jsonPath);

            return value;
        } 

    }
}