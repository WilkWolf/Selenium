using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject
{

    public static class PageObjectBasicForm
    {
        public static readonly string PageUrl = Helpers.GetValueFromSettings("..Page.Input.BasicForm");



        public const string XPathButtonSubmitMessage = "//*[@id='get-input']/button";
        public const string XPathButtonSubmitSum = "//*[@id='gettotal']/button";
        public const string XPathTextBoxMessage = "//*[@id='user-message']";
        public const string XPathTextBoxSum1 = "//*[@id='sum1']";
        public const string XPathTextBoxSum2 = "//*[@id='sum2']";
        public const string XPathDisplayMessage = "//*[@id='display']";
        public const string XPathDisplaySum = "//*[@id='displayvalue']";

         
        //maybe it can be deleted 
        private static IWebElement ButtonSubmitMessage;
        private static IWebElement ButtonSubmitSum;
        private static IWebElement TextBoxMessage;
        private static IWebElement TextBoxSum1;
        private static IWebElement TextBoxSum2;
        private static IWebElement DisplayMessage;
        private static IWebElement DisplaySum;


        public static IWebElement GetButtonSubmitMessage(ChromeDriver driver)
        {
            ButtonSubmitMessage = Helpers.GetWebElement(driver, XPathButtonSubmitMessage);
            return ButtonSubmitMessage;
        }

        public static IWebElement GetButtonSubmitSum(ChromeDriver driver)
        {
            ButtonSubmitSum = Helpers.GetWebElement(driver, XPathButtonSubmitSum);
            return ButtonSubmitSum;
        }

        public static IWebElement GetTextBoxMessage(ChromeDriver driver)
        {
            TextBoxMessage = Helpers.GetWebElement(driver, XPathTextBoxMessage);
            return TextBoxMessage;
        }

        public static IWebElement GetTextBoxSum1(ChromeDriver driver)
        {
            TextBoxSum1 = Helpers.GetWebElement(driver, XPathTextBoxSum1);
            return TextBoxSum1;
        }

        public static IWebElement GetTextBoxSum2(ChromeDriver driver)
        {
            TextBoxSum2 = Helpers.GetWebElement(driver, XPathTextBoxSum2);
            return TextBoxSum2;
        }

        public static IWebElement GetDisplayMessage(ChromeDriver driver)
        {
            DisplayMessage = Helpers.GetWebElement(driver, XPathDisplayMessage);
            return DisplayMessage;
        }
        public static IWebElement GetDisplaySum(ChromeDriver driver)
        {
            DisplaySum = Helpers.GetWebElement(driver, XPathDisplaySum);
            return DisplaySum;
        }
    }
}
