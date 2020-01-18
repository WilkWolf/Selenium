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
        //
        // Test IsElementExist maybe is not require because when test failed in order to not received WebElement then it failed anyway and as an output give correct error 
        //[Theory]
        //[InlineData(BasicCheckbox.IdCheckBoxAge, null)]
        //[InlineData(BasicCheckbox.IdMessageSelectedAge, null)]
        //[InlineData(BasicCheckbox.IdButtonCheck, null)]
        //[InlineData(null, XPathBasicCheckbox.CheckBox1)]
        //[InlineData(null, XPathBasicCheckbox.CheckBox2)]
        //[InlineData(null, XPathBasicCheckbox.CheckBox3)]
        //[InlineData(null, XPathBasicCheckbox.CheckBox4)]
        //public void IsElementExist(string id, string path)
        // {
        //    ChromeDriver driver = Helpers.RunPage(BasicForm.PageUrl);

        //    IWebElement element = Helpers.GetWebElement(driver,id, path);
        //    bool isElementExist = element != null;
        //    driver.Close();
        //    Assert.True(isElementExist, $"Element {id}{path} is not exist");
        //}

        //maybe this test will be remove 
        [Theory]
        [InlineData(BasicCheckbox.IdCheckBoxAge, null)] 
        [InlineData(BasicCheckbox.IdButtonCheck, null)]
        [InlineData(null, BasicCheckbox.XPathCheckBox1)]
        [InlineData(null, BasicCheckbox.XPathCheckBox2)]
        [InlineData(null, BasicCheckbox.XPathCheckBox3)]
        [InlineData(null, BasicCheckbox.XPathCheckBox4)]
        public void IsElementEnable(string id, string path)
        {
            ChromeDriver driver = Helpers.RunPage(BasicCheckbox.PageUrl);

            IWebElement element = Helpers.GetWebElement(driver, id, path);
            bool isEnable = element.Enabled;
            driver.Close();
            Assert.True(isEnable, $"Checkbox {id}{path} is not enabled");
        }


        [Fact]
        public void CheckboxMessage()
        {
            ChromeDriver driver = Helpers.RunPage(BasicForm.PageUrl);

            BasicCheckbox.GetCheckBoxAge(driver).Click();
            string result = BasicCheckbox.GetMessageSelectedAge(driver).Text;

            driver.Close();
            Assert.True(result == "Success - Check box is checked", "Message is not correct");
        }


        [Theory]
        [InlineData(BasicCheckbox.XPathCheckBox1)]
        [InlineData(BasicCheckbox.XPathCheckBox2)]
        [InlineData(BasicCheckbox.XPathCheckBox3)]
        [InlineData(BasicCheckbox.XPathCheckBox4)]
        public void CheckButtonTextWhenSingleCheckboxIsSelected(string xPath)
        {
            ChromeDriver driver = Helpers.RunPage(BasicCheckbox.PageUrl);
            IWebElement checkBox = driver.FindElementByXPath(xPath);
            checkBox.Click();
            string result = Helpers.GetValue(BasicCheckbox.GetButtonCheck(driver));
            driver.Close();
            Assert.True(result == "Check All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }

        [Fact]
        public void SelectRightFourCheckboxAndCheckMessage()
        {
            ChromeDriver driver = Helpers.RunPage(BasicCheckbox.PageUrl);

            BasicCheckbox.GetCheckBox1(driver).Click();
            BasicCheckbox.GetCheckBox2(driver).Click();
            BasicCheckbox.GetCheckBox3(driver).Click();
            BasicCheckbox.GetCheckBox4(driver).Click();

            string result = BasicCheckbox.GetButtonCheck(driver).Text;
            driver.Close();
            Assert.True(result == "Uncheck All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }

        [Fact]
        public void ClickUncheckAllButtonAndCheckText()
        {
            ChromeDriver driver = Helpers.RunPage(BasicCheckbox.PageUrl);

            BasicCheckbox.GetCheckBox1(driver).Click();
            BasicCheckbox.GetCheckBox2(driver).Click();
            BasicCheckbox.GetCheckBox3(driver).Click();
            BasicCheckbox.GetCheckBox4(driver).Click();

            BasicCheckbox.GetButtonCheck(driver).Click();
            string result = BasicCheckbox.GetButtonCheck(driver).Text;
            driver.Close();

            Assert.True(result == "Check All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }

        [Fact]
        public void CheckButtonMessageWhenSelectedThreeRightAndOneWrongCheckBox()
        {
            ChromeDriver driver = Helpers.RunPage(BasicCheckbox.PageUrl);
            BasicCheckbox.GetCheckBoxAge(driver).Click();
            BasicCheckbox.GetCheckBox2(driver).Click();
            BasicCheckbox.GetCheckBox3(driver).Click();
            BasicCheckbox.GetCheckBox4(driver).Click();

            string result = BasicCheckbox.GetButtonCheck(driver).Text;
            driver.Close();
            Assert.True(result == "Check All", $"Message is not correct \n Current: {result} \n Expected: Check All");
        }


    }
}
