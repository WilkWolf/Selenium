using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Input
{
    public class SimpleForm
    {

        [Fact]
        public void CheckUrl() { 
        
            ChromeDriver driver = Helpers.RunPage(BasicForm.PageUrl);

            Assert.True(driver.Url == "https://www.seleniumeasy.com/test/basic-first-form-demo.html", "Page not exist");
            driver.Close();
        }

        [Theory]
        [InlineData(null,BasicForm.ButtonSubmitMessage)]
        [InlineData(null,BasicForm.ButtonSubmitSum)]
        [InlineData(BasicForm.TextBoxMessage,null)]
        [InlineData(BasicForm.TextBoxSum1, null)]
        [InlineData(BasicForm.TextBoxSum2, null)]
        [InlineData(BasicForm.DisplayMessage, null)]
        [InlineData(BasicForm.DisplaySum, null)]
        public void IsElementExist(string id, string xPath)
        {
            ChromeDriver driver = Helpers.RunPage(BasicForm.PageUrl);
            IWebElement element = Helpers.GetWebElement(driver, id, xPath); 
            driver.Close();
            Assert.True(element != null, $"Element with id/XPath == {id}{xPath} does not exist");
         }

        [Theory]
        [InlineData(BasicForm.TextBoxMessage)]
        [InlineData(BasicForm.TextBoxSum1)]
        [InlineData(BasicForm.TextBoxSum2)]
        public void InputDataToTextForm (string inputId)
        {
            ChromeDriver driver = Helpers.RunPage(BasicForm.PageUrl);
            IWebElement element =  driver.FindElementById(inputId);
            Helpers.WriteText(element,"Test");
            string result = Helpers.GetValue(element);
            driver.Close();
            Assert.True(result == "Test", $"Textbox {inputId} test failed. \n Expected: Test \n Current: {result}");
        }

        [Theory]
        [InlineData(BasicForm.ButtonSubmitSum)]
        [InlineData(BasicForm.ButtonSubmitMessage)]
        public void IsButtonActive(string form)
        {
            ChromeDriver driver = Helpers.RunPage(BasicForm.PageUrl);
            bool isButtonEnable = driver.FindElementByXPath(form).Enabled;

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
            ChromeDriver driver = Helpers.RunPage(BasicForm.PageUrl);
            IWebElement textBox = Helpers.GetWebElement(driver, BasicForm.TextBoxMessage, null);
            IWebElement button = Helpers.GetWebElement(driver, null, BasicForm.ButtonSubmitMessage);
            IWebElement display = Helpers.GetWebElement(driver, BasicForm.DisplayMessage, null);
            Helpers.WriteText(textBox, text);
            button.Click();
            string result = display.Text;
            driver.Close();
            Assert.True(result == text, $"Test failed. \n Expected: {text} \n Current: {result} ");
        }

        [Theory]
        [InlineData("1","1","2")]
        [InlineData("0", "0", "0")]
        [InlineData("2000000000", "2000000000", "4000000000")]

        [InlineData("-1", "-1", "-2")]
        [InlineData("-0", "-0", "0")]
        [InlineData("-2000000000", "-2000000000", "-4000000000")]

        [InlineData("1", "-1", "0")]
        [InlineData("0", "-0", "0")]
        [InlineData("2000000000", "-2000000000", "0")]

        [InlineData("10", "-1", "9")]
        [InlineData("-10", "1", "-9")]

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
            ChromeDriver driver = Helpers.RunPage(BasicForm.PageUrl);
            IWebElement textBoxSum1 = Helpers.GetWebElement(driver, BasicForm.TextBoxSum1, null);
            IWebElement textBoxSum2 = Helpers.GetWebElement(driver, BasicForm.TextBoxSum2, null);
            IWebElement display = Helpers.GetWebElement(driver, BasicForm.DisplaySum, null);
            IWebElement button = Helpers.GetWebElement(driver, null, BasicForm.ButtonSubmitSum);
            textBoxSum1.SendKeys(valueA);
            textBoxSum2.SendKeys(valueB);
            button.Click();
            string result = display.Text;
            driver.Close();
            Assert.True(result == sum, $"Test failed. \n Expected: {sum} \n Current: {result} ");
        }
    }
}
