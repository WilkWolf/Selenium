

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject
{
    public static class BasicCheckbox
    {
        public static readonly string PageUrl = Helpers.GetValueFromSettings("..Page.Input.CheckBox");
        
        public const string IdCheckBoxAge = "isAgeSelected";
        public const string IdMessageSelectedAge = "txtAge";
        public const string XPathCheckBox1 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[1]/label/input";
        public const string XPathCheckBox2 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[2]/label/input";
        public const string XPathCheckBox3 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[3]/label/input";
        public const string XPathCheckBox4 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[4]/label/input";
        public const string IdButtonCheck = "check1";

        public static IWebElement GetCheckBoxAge(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, IdCheckBoxAge, null);
        }
        public static IWebElement GetMessageSelectedAge(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, IdMessageSelectedAge, null);
        }
        public static IWebElement GetCheckBox1(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null, XPathCheckBox1);
        }
        public static IWebElement GetCheckBox2(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null, XPathCheckBox2);
        }
        public static IWebElement GetCheckBox3(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null, XPathCheckBox3);
        }
        public static IWebElement GetCheckBox4(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null, XPathCheckBox4);
        }
        public static IWebElement GetButtonCheck(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, IdButtonCheck, null);
        }

    }
}


