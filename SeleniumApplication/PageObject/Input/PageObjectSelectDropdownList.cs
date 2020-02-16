using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject.Input
{
    public class PageObjectSelectDropdownList
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

        public readonly IList<string> ListOfMultiSelectValue = new ReadOnlyCollection<string>
        (new List<string> {
            "California","Florida","New Jersey","New York","Ohio","Texas","Pennsylvania","Washington"
        });

        public readonly string PageUrl = Helpers.GetValueFromSettings("..Page.Input.DropdownList");

        public const string XPathSelectListDropdown = "//*[@id='select-demo']";
        public const string XPathDisplaySelectListValue = "//*[@id='easycont']/div/div[2]/div[1]/div[2]/p[2]";
        public const string XPathSelectMultiListDropdown = "//*[@id='multi-select']";
        public const string XPathButtonFirstSelect = "//*[@id='printMe']";
        public const string XPathButtonGetAllSelected = "//*[@id='printAll']";
        public const string XPathDisplayMultiSelectDropdown = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/p[2]";

        public const string XPathSelect1 = "//*[@id='multi-select']/option[1]";
        public const string XPathSelect2 = "//*[@id='multi-select']/option[2]";
        public const string XPathSelect3 = "//*[@id='multi-select']/option[3]";
        public const string XPathSelect4 = "//*[@id='multi-select']/option[4]";
        public const string XPathSelect5 = "//*[@id='multi-select']/option[5]";
        public const string XPathSelect6 = "//*[@id='multi-select']/option[6]";
        public const string XPathSelect7 = "//*[@id='multi-select']/option[7]";
        public const string XPathSelect8 = "//*[@id='multi-select']/option[8]";

        public IWebElement GetDisplaySelectListValue(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathDisplaySelectListValue);
        public IWebElement GetButtonFirstSelect(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonFirstSelect);
        public IWebElement GetButtonGetAllSelected(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonGetAllSelected);
        public IWebElement GetDisplayMultiSelectDropdown(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathDisplayMultiSelectDropdown);
        public IWebElement GetButtonSelect1(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathSelect1);
        public IWebElement GetButtonSelect2(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathSelect2);
        public IWebElement GetButtonSelect3(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathSelect3);
        public IWebElement GetButtonSelect4(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathSelect4);
        public IWebElement GetButtonSelect5(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathSelect5);
        public IWebElement GetButtonSelect6(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathSelect6);
        public IWebElement GetButtonSelect7(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathSelect7);
        public IWebElement GetButtonSelect8(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathSelect8);

        public IWebElement GetMultiSelectDropdown(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathSelectMultiListDropdown);
        public SelectElement GetSelectListDropdown(ChromeDriver driver)
        {
            IWebElement element = Helpers.GetWebElement(driver, XPathSelectListDropdown);
            SelectElement dropdownList = new SelectElement(element);
            return dropdownList;
        }
        public SelectElement GetSelectMultiListDropdown(ChromeDriver driver)
        {
            IWebElement element = Helpers.GetWebElement(driver, XPathSelectMultiListDropdown);
            SelectElement dropdownList = new SelectElement(element);
            return dropdownList;
        }
    }
}
