using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject
{
    public static class PageObjectBasicRadioButton
    {

        public static string PageUrl = "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html";

        public static string  XPathRadioButtonMale= "//*[@id='easycont']/div/div[2]/div[1]/div[2]/label[1]/input";
        public static string  XPathRadioButtonFemale = "//*[@id='easycont']/div/div[2]/div[1]/div[2]/label[2]/input";
        public static string  IdButtonGetCheckedValue = "buttoncheck";
        public static string  XPathDisplayFirstMessage = "//*[@id='easycont']/div/div[2]/div[1]/div[2]/p[3]";

        public static string  XPathGroupRadioButtonMale = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[1]/label[1]/input";
        public static string XPathGroupRadioButtonFemale = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[1]/label[2]";
        public static string XPathGroupRadioButtonAge0To5 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[2]/label[1]/input";
        public static string XPathGroupRadioButtonMale5To15 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[2]/label[2]/input";
        public static string XPathGroupRadioButtonMale15To50 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[2]/label[3]/input";
        public static string XPathGroupButtonGetValues = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/button";
        public static string XPathGroupDisplay = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/p[2]";
       
        public static IWebElement GetRadioButtonMale(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null, XPathRadioButtonMale);
        }

        public static IWebElement GetRadioButtonFemale(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null, XPathRadioButtonFemale);
        }

        public static IWebElement GetButtonGetCheckedValue(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null, IdButtonGetCheckedValue);
        }
        public static IWebElement GetDisplayFirstMessage(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null, XPathDisplayFirstMessage);
        }
        public static IWebElement GetGroupRadioButtonMale(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null, XPathGroupRadioButtonMale);
        }
        public static IWebElement GetGroupRadioButtonFemale(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null, XPathGroupRadioButtonFemale);
        }
        public static IWebElement GetGroupRadioButtonAge0To5(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null, XPathGroupRadioButtonAge0To5);
        }
        public static IWebElement GetGroupRadioButtonAge5To15(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null, XPathGroupRadioButtonMale5To15);
        }
        public static IWebElement GetGroupRadioButtonAge15To50(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null, XPathGroupRadioButtonMale15To50);
        }
        public static IWebElement GetGroupButtonGetValues(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null, XPathGroupButtonGetValues);
        }
        public static IWebElement GetGroupDisplay(ChromeDriver driver)
        {
            return Helpers.GetWebElement(driver, null, XPathGroupDisplay);
        }


    }
}
