using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumApplication.Shared
{
    static class  Helpers
    {
        public static ChromeDriver RunPage(string pageUrl)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(pageUrl);
            // driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
