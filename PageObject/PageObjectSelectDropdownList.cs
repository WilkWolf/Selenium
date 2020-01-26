using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject
{
    public static class PageObjectSelectDropdownList
    {
        public enum EnumSelectListValues
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }

        public enum EnumMultiSelectValues
        {
            California,
            Florida,
            NewJersey,
            NewYork,
            Ohio,
            Texas,
            Pennsylvania,
            Washington
        }

        public static Dictionary<string,string> DictSelectList = new Dictionary<string, string>()
        {
            {"Sunday", "Sunday"},
            {"Monday", "Monday"},
            {"Tueseday", "Tueseday"},
            {"Wednesday", "Wednesday"},
            {"Thursday", "Thursday"},
            {"Friday", "Friday"},
            {"Saturday", "Saturday"}
        };

        public static Dictionary<string, string> DictSelectMultiList = new Dictionary<string, string>()
        {
            {"California", "California"},
            {"Florida", "Florida"},
            {"NewJersey", "New Jersey"},
            {"NewYork", "New York"},
            {"Ohio", "Ohio"},
            {"Texas", "Texas"},
            {"Pennsylvania", "Pennsylvania"},
            {"Washington","Washington" }
        };

        public static string PageUrl = Helpers.GetValueFromSettings("..Page.Input.DropdownList");

        public static string XPathSelectListDropdown = "//*[@id='select-demo']";
        public static string XPathDisplaySelectListValue = "//*[@id='easycont']/div/div[2]/div[1]/div[2]/p[2]";
        public static string XPathSelectMultiListDropdown = "//*[@id='multi-select']";
        public static string XPathButtonFirstSelect = "//*[@id='printMe']";
        public static string XPathButtonGetAllSelected = "//*[@id='printAll']";
        public static string XPathDisplayMultiSelectDropdown = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/p[2]";

        public static IWebElement GetSelectListDropdown(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, XPathSelectListDropdown);
        }
        public static IWebElement GetDisplaySelectListValue(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, XPathDisplaySelectListValue);
        }

        public static IWebElement GetSelectMultiListDropdown(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, XPathSelectMultiListDropdown);
        }
        public static IWebElement GetButtonFirstSelect(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, XPathButtonFirstSelect);
        }

        public static IWebElement GetButtonGetAllSelected(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, XPathButtonGetAllSelected);
        }
        public static IWebElement GetDisplayMultiSelectDropdown(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, XPathDisplayMultiSelectDropdown);
        }
    }
}
