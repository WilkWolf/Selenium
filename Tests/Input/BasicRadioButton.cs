using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Input
{
    class BasicRadioButton
    {
        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicRadioButton.PageUrl);

            Assert.True(driver.Url == "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html", "Page not exist");
            driver.Close();
        }

        public void CheckFirstButtonText()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicRadioButton.PageUrl);

          string result =  PageObjectBasicRadioButton.GetButtonGetCheckedValue(driver).Text;

          Assert.True(result == "Checked value", $"Button text is not as expected \n Expected: Checked value \n Current: {result}" );
        }


    }
}
