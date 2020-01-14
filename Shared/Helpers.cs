using OpenQA.Selenium.Chrome;
using System.IO;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;

namespace SeleniumApplication.Shared
{
    static class  Helpers
    {
        public static ChromeDriver RunPage(string pageUrl)
        {
            string url = GetPage(pageUrl);
           ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            var driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl(url);
            return driver;
        }

        private static string GetPage(string page)
        {
           return  GetValueFromSettings("..Base") + page;
        }

        public static string GetValueFromSettings(string jsonPath)
        {
            string jsonSettingsFile = File.ReadAllText("Settings.json");
            JObject settingsObject = JObject.Parse(jsonSettingsFile);
            string value = (string)settingsObject.SelectToken(jsonPath);

            return value;
        }

        public static IWebElement GetWebElement(ChromeDriver driver, string id, string xPath)
        {
            IWebElement element =   id == null ? driver.FindElementByXPath(xPath) : driver.FindElementById(id);
          return element;
        }

        public static string GetValue(IWebElement element)
        {
            string value = element.GetAttribute("value");
            return value;
        }

        public static void WriteText(IWebElement textBox, string text)
        {
            textBox.SendKeys(text);
        }

    }
}