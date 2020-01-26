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
        
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicForm.PageUrl);

            Assert.True(driver.Url == "https://www.seleniumeasy.com/test/basic-first-form-demo.html", "Page not exist");
            driver.Close();
        }



        [Theory]
        [InlineData(PageObjectBasicForm.XPathTextBoxSum1)]
        [InlineData(PageObjectBasicForm.XPathTextBoxSum2)]
        public void InputNonNumberTextToSumTextBoxForm(string inputId)
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicForm.PageUrl);

            IWebElement element = driver.FindElementByXPath(inputId);
            Helpers.WriteText(element, "Test");
            PageObjectBasicForm.GetButtonSubmitSum(driver).Click();

            string result = Helpers.GetValue(element);
            driver.Close();

            Assert.True(result == "", $"Textbox {inputId} test failed. Value should number. \n Expected: Test \n Current: {result}");
        }


        [Theory]
        [InlineData("Test")]
        [InlineData("1234567890")]
        [InlineData("Test123")]
        [InlineData("     ")]
        [InlineData("")]

        public void SendMessageToFormGetInput(string text)
        {

            ChromeDriver driver = Helpers.RunPage(PageObjectBasicForm.PageUrl);
            PageObjectSelectDropdownList.GetSelectListDropdown(driver);
            Helpers.WriteText(PageObjectBasicForm.GetTextBoxMessage(driver), text);
            PageObjectBasicForm.GetButtonSubmitMessage(driver).Click();
            string result = PageObjectBasicForm.GetDisplayMessage(driver).Text;
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
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicForm.PageUrl);

            PageObjectBasicForm.GetTextBoxSum1(driver).SendKeys(valueA);
            PageObjectBasicForm.GetTextBoxSum2(driver).SendKeys(valueB);
            PageObjectBasicForm.GetButtonSubmitSum(driver).Click();
            string result = PageObjectBasicForm.GetDisplaySum(driver).Text;

            driver.Close();
            Assert.True(result == sum, $"Test failed. \n Expected: {sum} \n Current: {result} ");
        }
    }
}
