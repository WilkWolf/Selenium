using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Input
{
    public class Checkbox
    {
        public string pageUrl = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(pageUrl);

            Assert.True(driver.Url == pageUrl, "Page not exist");
            driver.Close();
        }
        [Theory]
        [InlineData("isAgeSelected",null)]
        [InlineData("txtAge", null)]
        [InlineData("check1", null)]
        [InlineData(null, "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[1]/label/input")]
        [InlineData(null, "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[2]/label/input")]
        [InlineData(null, "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[3]/label/input")]
        [InlineData(null, "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[4]/label/input")]
        public void IsElementExist(string id, string path)
        {
            ChromeDriver driver = Helpers.RunPage(pageUrl);

            IWebElement element = id != null ? driver.FindElementById(id) : driver.FindElementByXPath(path);
            driver.Close();
            Assert.True(element != null,$"Element {id}{path} is not exist");
        }

        [Theory]
        [InlineData("isAgeSelected", null)]
        [InlineData("check1", null)]
        [InlineData(null, "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[1]/label/input")]
        [InlineData(null, "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[2]/label/input")]
        [InlineData(null, "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[3]/label/input")]
        [InlineData(null, "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[4]/label/input")]
        public void IsElementEnable(string id, string path)
        {
            ChromeDriver driver = Helpers.RunPage(pageUrl);

            IWebElement element = id != null ? driver.FindElementById(id) : driver.FindElementByXPath(path);
            bool isEnable = element.Enabled;
            driver.Close();
            Assert.True(isEnable, $"Checkbox {id}{path} is not enabled");
        }

        [Fact]
        public void IsMessageHidden()
        {
            ChromeDriver driver = Helpers.RunPage(pageUrl);

            IWebElement message = driver.FindElementById("txtAge");
            driver.Close();
            Assert.False(message.Displayed, $"Message is not hidden"); 
        }

        [Fact]
        public void IsMessageVisible()
        {
            ChromeDriver driver = Helpers.RunPage(pageUrl);
            driver.FindElementById("isAgeSelected").Click();
            IWebElement message = driver.FindElementById("txtAge");
            driver.Close();
            Assert.False(message.Displayed, $"Message is not show");
        }

        [Fact]
        public void CheckboxMessage()
        {
            ChromeDriver driver = Helpers.RunPage(pageUrl);

            driver.FindElementById("isAgeSelected").Click();
            IWebElement message = driver.FindElementById("txtAge");
            driver.Close();
            Assert.True(message.Text == "Success - Check box is checked", $"Message is not correct");
        }


    }
}
