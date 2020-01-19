
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Input
{
    public class BasicRadioButton
    {
        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicRadioButton.PageUrl);

            Assert.True(driver.Url == "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html", $"Page not exist \n Current:{driver.Url}\n Expected:https://www.seleniumeasy.com/test/basic-radiobutton-demo.html ");
            driver.Close();
        }
        [Fact]
        public void CheckFirstButtonText()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicRadioButton.PageUrl);

            string result = PageObjectBasicRadioButton.GetButtonGetCheckedValue(driver).Text;

            Assert.True(result == "Get Checked value", $"Button text is not as expected \n Expected: Checked value \n Current: {result}");
        }


        [Fact]
        public void ClickButtonWithoutCheckedAnyRadioButton()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicRadioButton.PageUrl);

            Helpers.GetWebElement(driver,null, PageObjectBasicRadioButton.XPathButtonGetCheckedValue).Click();
            string result = PageObjectBasicRadioButton.GetDisplayFirstMessage(driver).Text;

            Assert.True(result == "Radio button is Not checked", $"Button text is not as expected \n Expected: Checked value \n Current: {result}");
        }

        [Fact]
        public void ClickGroupButtonWithoutCheckedAnyRadioButton()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicRadioButton.PageUrl);

            PageObjectBasicRadioButton.GetGroupButtonGetValues(driver).Click();
            string result = PageObjectBasicRadioButton.GetGroupDisplay(driver).Text;
            string expectedResult = "Sex :\r\nAge group:";
            Assert.True(result == expectedResult, $"Button text is not as expected \n Expected: {expectedResult}\n Current: {result}");
        }

        [Theory]
        [InlineData(PageObjectBasicRadioButton.XPathRadioButtonMale,"Male")]
        [InlineData(PageObjectBasicRadioButton.XPathRadioButtonFemale,"Female")]
        public void SelectRadioButtonAndCheckDisplayedText(string radioButton, string gender)
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicRadioButton.PageUrl);
            Helpers.GetWebElement(driver,null,radioButton).Click();
            PageObjectBasicRadioButton.GetButtonGetCheckedValue(driver).Click();

            string result = PageObjectBasicRadioButton.GetDisplayFirstMessage(driver).Text;

            Assert.True(result == $"Radio button '{gender}' is checked", $"Button text is not as expected \n Expected: Checked value \n Current: {result}");
        }


    }
}
