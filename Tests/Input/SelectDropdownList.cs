using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Input
{
    public class SelectDropdownList
    {
        [Fact]
        public void CheckUrl()
        {

            ChromeDriver driver = Helpers.RunPage(PageObjectSelectDropdownList.PageUrl);

            Assert.True(driver.Url == "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html", "Page not exist");
            driver.Close();
        }

    }
}
