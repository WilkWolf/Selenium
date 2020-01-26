

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject
{
    public static class PageObjectBasicCheckbox
    {
        public static readonly string PageUrl = Helpers.GetValueFromSettings("..Page.Input.CheckBox");
        
        public const string XPathCheckBoxAge = "//*[@id='isAgeSelected']";
        public const string XPathMessageSelectedAge = "//*[@id='txtAge']";
        public const string XPathCheckBox1 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[1]/label/input";
        public const string XPathCheckBox2 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[2]/label/input";
        public const string XPathCheckBox3 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[3]/label/input";
        public const string XPathCheckBox4 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[4]/label/input";
        public const string XPathButtonCheck = "//*[@id='check1']";
 

        public static IWebElement GetCheckBoxAge(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, XPathCheckBoxAge);
        }
        public static IWebElement GetMessageSelectedAge(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, XPathMessageSelectedAge);
        }
        public static IWebElement GetCheckBox1(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, XPathCheckBox1);
        }
        public static IWebElement GetCheckBox2(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, XPathCheckBox2);
        }
        public static IWebElement GetCheckBox3(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, XPathCheckBox3);
        }
        public static IWebElement GetCheckBox4(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, XPathCheckBox4);
        }
        public static IWebElement GetButtonCheck(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null);
        }

    }
}


