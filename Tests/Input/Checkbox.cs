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
            ChromeDriver driver = Helpers.RunPage(BasicCheckbox.PageUrl);

            Assert.True(driver.Url == "https://www.seleniumeasy.com/test/basic-checkbox-demo.html", "Page not exist");
            driver.Close();
        }
        [Theory]
        [InlineData(BasicCheckbox.CheckBoxAge, null)]
        [InlineData(BasicCheckbox.MessageSelectedAge, null)]
        [InlineData(BasicCheckbox.ButtonCheck, null)]
        [InlineData(null, BasicCheckbox.CheckBox1)]
        [InlineData(null, BasicCheckbox.CheckBox2)]
        [InlineData(null, BasicCheckbox.CheckBox3)]
        [InlineData(null, BasicCheckbox.CheckBox4)]
        public void IsElementExist(string id, string path)
        {
            ChromeDriver driver = Helpers.RunPage(BasicForm.PageUrl);

            IWebElement element = Helpers.GetWebElement(driver,id, path);
            bool isElementExist = element != null;
            driver.Close();
            Assert.True(isElementExist, $"Element {id}{path} is not exist");
        }

        [Theory]
        [InlineData(BasicCheckbox.CheckBoxAge, null)]
        [InlineData(BasicCheckbox.ButtonCheck, null)]
        [InlineData(null, BasicCheckbox.CheckBox1)]
        [InlineData(null, BasicCheckbox.CheckBox2)]
        [InlineData(null, BasicCheckbox.CheckBox3)]
        [InlineData(null, BasicCheckbox.CheckBox4)]
        public void IsElementEnable(string id, string path)
        {
            ChromeDriver driver = Helpers.RunPage(BasicForm.PageUrl);

            IWebElement element = Helpers.GetWebElement(driver, id, path);
            bool isEnable = element.Enabled;
            driver.Close();
            Assert.True(isEnable, $"Checkbox {id}{path} is not enabled");
        }
        [Fact]
        public void CheckboxMessage()
        {
            ChromeDriver driver = Helpers.RunPage(BasicForm.PageUrl);
            IWebElement checkBox = driver.FindElementById(BasicCheckbox.CheckBoxAge);
            IWebElement message = driver.FindElementById(BasicCheckbox.MessageSelectedAge);

            checkBox.Click();
            string result = message.Text;

            driver.Close();
            Assert.True(result == "Success - Check box is checked", "Message is not correct");
        }


        [Theory]
        [InlineData(BasicCheckbox.CheckBox1)]
        [InlineData(BasicCheckbox.CheckBox2)]
        [InlineData(BasicCheckbox.CheckBox3)]
        [InlineData(BasicCheckbox.CheckBox4)]
        public void CheckButtonTextWhenSingleCheckboxIsSelected(string xPath)
        {
            ChromeDriver driver = Helpers.RunPage(BasicCheckbox.PageUrl);
            IWebElement checkBox = driver.FindElementByXPath(xPath);
            IWebElement button = driver.FindElementById(BasicCheckbox.ButtonCheck);
            checkBox.Click();
            string result = Helpers.GetValue(button);
            driver.Close();
            Assert.True(result == "Check All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }

        [Fact]
        public void SelectRightFourCheckboxAndCheckMessage()
        {
            ChromeDriver driver = Helpers.RunPage(BasicCheckbox.PageUrl);
 driver.FindElementByXPath(BasicCheckbox.CheckBox1).Click();
           driver.FindElementByXPath(BasicCheckbox.CheckBox2).Click();
             driver.FindElementByXPath(BasicCheckbox.CheckBox3).Click();
            driver.FindElementByXPath(BasicCheckbox.CheckBox4).Click();
            IWebElement button = driver.FindElementById(BasicCheckbox.ButtonCheck);

            string result = Helpers.GetValue(button);
            driver.Close();
            Assert.True(result == "Uncheck All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }

        [Fact]
        public void ClickUncheckAllButtonAndCheckText()
        {
            ChromeDriver driver = Helpers.RunPage(BasicCheckbox.PageUrl);
            driver.FindElementByXPath(BasicCheckbox.CheckBox1).Click();
            driver.FindElementByXPath(BasicCheckbox.CheckBox2).Click();
            driver.FindElementByXPath(BasicCheckbox.CheckBox3).Click();
            driver.FindElementByXPath(BasicCheckbox.CheckBox4).Click();
            IWebElement button = driver.FindElementById(BasicCheckbox.ButtonCheck);
            button.Click();
            string result = Helpers.GetValue(button);
            driver.Close();
            Assert.True(result == "Check All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }

        [Fact]
        public void CheckButtonMessageWhenSelectedThreeRightAndOneWrongCheckBox()
        {
            ChromeDriver driver = Helpers.RunPage(BasicCheckbox.PageUrl);
            driver.FindElementById(BasicCheckbox.CheckBoxAge).Click();
            driver.FindElementByXPath(BasicCheckbox.CheckBox2).Click();
            driver.FindElementByXPath(BasicCheckbox.CheckBox3).Click();
            driver.FindElementByXPath(BasicCheckbox.CheckBox4).Click();
            IWebElement button = driver.FindElementById(BasicCheckbox.ButtonCheck);
            string result = Helpers.GetValue(button);
            driver.Close();
            Assert.True(result == "Check All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }


    }
}
