using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Input
{
    public class Checkbox
    {
    
        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicCheckbox.PageUrl);

            Assert.True(driver.Url == "https://www.seleniumeasy.com/test/basic-checkbox-demo.html", "Page not exist");
            driver.Close();
        }



        [Fact]
        public void CheckboxMessage()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicForm.PageUrl);

            PageObjectBasicCheckbox.GetCheckBoxAge(driver).Click();
            string result = PageObjectBasicCheckbox.GetMessageSelectedAge(driver).Text;

            driver.Close();
            Assert.True(result == "Success - Check box is checked", "Message is not correct");
        }


        [Theory]
        [InlineData(PageObjectBasicCheckbox.XPathCheckBox1)]
        [InlineData(PageObjectBasicCheckbox.XPathCheckBox2)]
        [InlineData(PageObjectBasicCheckbox.XPathCheckBox3)]
        [InlineData(PageObjectBasicCheckbox.XPathCheckBox4)]
        public void CheckButtonTextWhenSingleCheckboxIsSelected(string xPath)
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicCheckbox.PageUrl);
            IWebElement checkBox = driver.FindElementByXPath(xPath);
            checkBox.Click();
            string result = Helpers.GetValue(PageObjectBasicCheckbox.GetButtonCheck(driver));
            driver.Close();
            Assert.True(result == "Check All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }

        [Fact]
        public void SelectRightFourCheckboxAndCheckMessage()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicCheckbox.PageUrl);

            PageObjectBasicCheckbox.GetCheckBox1(driver).Click();
            PageObjectBasicCheckbox.GetCheckBox2(driver).Click();
            PageObjectBasicCheckbox.GetCheckBox3(driver).Click();
            PageObjectBasicCheckbox.GetCheckBox4(driver).Click();

            string result = PageObjectBasicCheckbox.GetButtonCheck(driver).Text;
            driver.Close();
            Assert.True(result == "Uncheck All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }

        [Fact]
        public void ClickUncheckAllButtonAndCheckText()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicCheckbox.PageUrl);

            PageObjectBasicCheckbox.GetCheckBox1(driver).Click();
            PageObjectBasicCheckbox.GetCheckBox2(driver).Click();
            PageObjectBasicCheckbox.GetCheckBox3(driver).Click();
            PageObjectBasicCheckbox.GetCheckBox4(driver).Click();

            PageObjectBasicCheckbox.GetButtonCheck(driver).Click();
            string result = PageObjectBasicCheckbox.GetButtonCheck(driver).Text;
            driver.Close();

            Assert.True(result == "Check All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }

        [Fact]
        public void CheckButtonMessageWhenSelectedThreeRightAndOneWrongCheckBox()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectBasicCheckbox.PageUrl);
            PageObjectBasicCheckbox.GetCheckBoxAge(driver).Click();
            PageObjectBasicCheckbox.GetCheckBox2(driver).Click();
            PageObjectBasicCheckbox.GetCheckBox3(driver).Click();
            PageObjectBasicCheckbox.GetCheckBox4(driver).Click();

            string result = PageObjectBasicCheckbox.GetButtonCheck(driver).Text;
            driver.Close();
            Assert.True(result == "Check All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }


    }
}
