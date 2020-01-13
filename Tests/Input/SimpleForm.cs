using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Input
{
    public class SimpleForm
    {

        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(Configuration.SimpleFormUrl);

            Assert.True(driver.Url == "https://www.seleniumeasy.com/test/basic-first-form-demo.html", "Page not exist");
            driver.Close();
        }


        [Theory]
        [InlineData("get-input")]
        [InlineData("user-message")]
        [InlineData("display")]
        [InlineData("gettotal")]
        [InlineData("sum1")]
        [InlineData("sum2")]
        [InlineData("displayvalue")]
        public void IsElementExist(string id)
        {
            ChromeDriver driver = Helpers.RunPage(Configuration.SimpleFormUrl);
            var textBox = driver.FindElementById(id);
            driver.Close();
            Assert.True(textBox != null, $"Form with id == {id} does not exist");
         }

        [Theory]
        [InlineData("user-message")]
        [InlineData("sum1")]
        [InlineData("sum2")]
        public void InputDataToTextForm (string inputId)
        {
            ChromeDriver driver = Helpers.RunPage(Configuration.SimpleFormUrl);
            driver.FindElementById(inputId).SendKeys("Test");
            var result = driver.FindElementById(inputId).GetAttribute("value");
            driver.Close();
            Assert.True(result == "Test", $"Textbox {inputId} test failed. \n Expected: Test \n Current: {result}");
        }

        [Theory]
        [InlineData("get-input")]
        [InlineData("gettotal")]
        public void IsButtonActive(string form)
        {
            ChromeDriver driver = Helpers.RunPage(Configuration.SimpleFormUrl);
            IWebElement button = driver.FindElement(By.XPath($"//*[@id='{form}']/button"));
          
            var isButtonEnable = button.Enabled;
            driver.Close();

            Assert.True(isButtonEnable);
        }

        [Theory]
        [InlineData("Test")]
        [InlineData("1234567890")]
        [InlineData("Test123")]
        [InlineData("     ")]
        [InlineData("")]

        public void SendMessageToFormGetInput(string text)
        {
            ChromeDriver driver = Helpers.RunPage(Configuration.SimpleFormUrl);
            IWebElement button = driver.FindElement(By.XPath("//*[@id='get-input']/button"));

            driver.FindElementById("user-message").SendKeys(text);
            button.Click();

            var result =  driver.FindElementById("display").Text;
            driver.Close();
            Assert.True(result == text, $"Test failed. \n Expected: {text} \n Current: {result} ");
        }


        [Theory]
        [InlineData("1","1","2")]
        [InlineData("0", "0", "0")]
        [InlineData("1000000000", "1000000000", "2000000000")]
        [InlineData("2000000000", "2000000000", "4000000000")]

        [InlineData("-1", "-1", "-2")]
        [InlineData("-0", "-0", "0")]
        [InlineData("-1000000000", "-1000000000", "-2000000000")]
        [InlineData("-2000000000", "-2000000000", "-4000000000")]

        [InlineData("1", "-1", "0")]
        [InlineData("0", "-0", "0")]
        [InlineData("1000000000", "-1000000000", "0")]
        [InlineData("2000000000", "-2000000000", "0")]

        [InlineData("10", "-1", "9")]
        [InlineData("-10", "1", "-9")]
        [InlineData("2000000000", "-1000000000", "1000000000")]
        [InlineData("1000000000", "-2000000000", "-1000000000")]

        [InlineData("a", "b", "NaN")]
        [InlineData(" ", "b", "NaN")]
        [InlineData("a", " ", "NaN")]
        [InlineData(" ", " ", "NaN")]
        [InlineData("", "", "NaN")]

        [InlineData("1a", "1b", "NaN")]
        [InlineData("a", "1b", "NaN")]
        [InlineData("1a", "b", "NaN")]
        [InlineData("1.1", "1.1", "2.2")]
        [InlineData("1.1", "1.1", "NaN")]
        public void SendMessageToFormGetTotal(string valueA, string valueB, string sum)
        {
            ChromeDriver driver = Helpers.RunPage(Configuration.SimpleFormUrl);
            IWebElement button = driver.FindElement(By.XPath("//*[@id='gettotal']/button"));

            driver.FindElementById("sum1").SendKeys(valueA);
            driver.FindElementById("sum2").SendKeys(valueB);

            button.Click();

            var result = driver.FindElementById("displayvalue").Text;
            driver.Close();
            Assert.True(result == sum, $"Test failed. \n Expected: {sum} \n Current: {result} ");

        }

    }
}
