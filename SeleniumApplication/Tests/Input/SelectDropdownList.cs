using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumApplication.PageObject.Input;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Input
{
    public class SelectDropdownList
    {
        private readonly PageObjectSelectDropdownList _pageObjects = new PageObjectSelectDropdownList();

        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            string url = driver.Url;

            Helpers.AssertTrue(driver, url == "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html", "Page not exist");
        }

        [Theory]
        [InlineData(PageObjectSelectDropdownList.EnumSelectListValues.Sunday)]
        [InlineData(PageObjectSelectDropdownList.EnumSelectListValues.Monday)]
        [InlineData(PageObjectSelectDropdownList.EnumSelectListValues.Tuesday)]
        [InlineData(PageObjectSelectDropdownList.EnumSelectListValues.Thursday)]
        [InlineData(PageObjectSelectDropdownList.EnumSelectListValues.Wednesday)]
        [InlineData(PageObjectSelectDropdownList.EnumSelectListValues.Saturday)]
        [InlineData(PageObjectSelectDropdownList.EnumSelectListValues.Friday)]
        public void SelectFromSelectDropdownListAndCheckDisplay(Enum dropdownListValue)
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            _pageObjects.GetSelectListDropdown(driver).SelectByValue(dropdownListValue.ToString());

            string result = _pageObjects.GetDisplaySelectListValue(driver).Text;


            Helpers.AssertTrue(driver, result == $"Day selected :- {dropdownListValue.ToString()}", $"Exptected value: Day selected: - {dropdownListValue.ToString()}\nCurrent: {result}");
        }

        [Theory]
        [InlineData(PageObjectSelectDropdownList.XPathButtonFirstSelect, "First selected option is :")]
        [InlineData(PageObjectSelectDropdownList.XPathButtonGetAllSelected, "Options selected are :")]
        public void ClickButtonWithoutSelectAnyValue(string xPathButton, string expectedValue)
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            driver.FindElementByXPath(xPathButton).Click();
            string result = _pageObjects.GetDisplayMultiSelectDropdown(driver).Text;


            Helpers.AssertTrue(driver, result == expectedValue, $"Wrong message. \nExpected:{expectedValue}\nCurrent:{result}");
        }

        [Fact]
        public void SelectAllValueFromMultiSelectDropdown()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            string expectedResult = "Options selected are : California,Florida,New Jersey,New York,Ohio,Texas,Pennsylvania,Washington";

            Actions action = new Actions(driver);

            action.KeyDown(Keys.Control).DoubleClick(_pageObjects.GetMultiSelectDropdown(driver)).
                Click(_pageObjects.GetButtonSelect1(driver)).
                Click(_pageObjects.GetButtonSelect2(driver)).
                Click(_pageObjects.GetButtonSelect3(driver)).
                Click(_pageObjects.GetButtonSelect4(driver)).
                Click(_pageObjects.GetButtonSelect5(driver)).
                Click(_pageObjects.GetButtonSelect6(driver)).
                Click(_pageObjects.GetButtonSelect7(driver)).
                Click(_pageObjects.GetButtonSelect8(driver)).
                KeyUp(Keys.Control).
                Build().
                Perform();

            _pageObjects.GetButtonGetAllSelected(driver).Click();

            string result = _pageObjects.GetDisplayMultiSelectDropdown(driver).Text;


            Helpers.AssertTrue(driver, result == expectedResult, $"Expected:{expectedResult}\nCurrent:{result}");
        }



    }
}
