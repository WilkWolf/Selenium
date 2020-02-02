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
        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectSelectDropdownList.PageUrl);

            Assert.True(driver.Url == "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html", "Page not exist");
            driver.Close();
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
            ChromeDriver driver = Helpers.RunPage(PageObjectSelectDropdownList.PageUrl);

           PageObjectSelectDropdownList.GetSelectListDropdown(driver).SelectByValue(dropdownListValue.ToString());

            string result = PageObjectSelectDropdownList.GetDisplaySelectListValue(driver).Text;

            Assert.True(result == $"Day selected :- {dropdownListValue.ToString()}", $"Exptected value: Day selected: - {dropdownListValue.ToString()}\nCurrent: {result}");
        }

        [Theory]
        [InlineData(PageObjectSelectDropdownList.XPathButtonFirstSelect, "First selected option is :")]
        [InlineData(PageObjectSelectDropdownList.XPathButtonGetAllSelected, "Options selected are :")]
        public void ClickButtonWithoutSelectAnyValue(string xPathButton, string expectedValue)
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectSelectDropdownList.PageUrl);
            driver.FindElementByXPath(xPathButton).Click();
            string result = PageObjectSelectDropdownList.GetDisplayMultiSelectDropdown(driver).Text;

            Assert.True(result == expectedValue, $"Wrong message. \nExpected:{expectedValue}\nCurrent:{result}");
        }

        [Fact]
        public void SelectAllValueFromMultiSelectDropdown()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjectSelectDropdownList.PageUrl);
            var listOfMultiSelectValues = PageObjectSelectDropdownList.ListOfMultiSelectValue;
            string expectedResult = "Options selected are : California,Florida,New Jersey,New York,Ohio,Texas,Pennsylvania,Washington";
          
            var multiSelect = PageObjectSelectDropdownList.GetSelectMultiListDropdown(driver);
            Actions action= new Actions(driver);
            action.KeyDown(Keys.LeftControl);
            for (int i = 0; i < listOfMultiSelectValues.Count(); i++)
            { 
                multiSelect.SelectByValue(listOfMultiSelectValues.ElementAt(i));
            }

            var a = multiSelect.AllSelectedOptions;
            action.KeyUp(Keys.LeftControl);
            PageObjectSelectDropdownList.GetButtonGetAllSelected(driver).Click();

            string result = PageObjectSelectDropdownList.GetDisplayMultiSelectDropdown(driver).Text;

            Assert.True(result == expectedResult,$"Expected:{expectedResult}\nCurrent:{result}");

        }



    }
}
