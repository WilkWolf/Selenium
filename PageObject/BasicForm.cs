using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject
{

    public static class BasicForm
    {
        public static readonly string PageUrl = Helpers.GetValueFromSettings("..Page.Input.BasicForm");



        public const string XPathButtonSubmitMessage = "//*[@id='get-input']/button";
        public const string XPathButtonSubmitSum = "//*[@id='gettotal']/button";
        public const string IdTextBoxMessage = "user-message";
        public const string IdTextBoxSum1 = "sum1";
        public const string IdTextBoxSum2 = "sum2";
        public const string IdDisplayMessage = "display";
        public const string IdDisplaySum = "displayvalue";

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
            ButtonSubmitMessage = Helpers.GetWebElement(driver, null, XPathButtonSubmitMessage);
            return ButtonSubmitMessage;
        }

        public static IWebElement GetButtonSubmitSum(ChromeDriver driver)
        {
            ButtonSubmitSum = Helpers.GetWebElement(driver, null, XPathButtonSubmitSum);
            return ButtonSubmitSum;
        }

        public static IWebElement GetTextBoxMessage(ChromeDriver driver)
        {
            TextBoxMessage = Helpers.GetWebElement(driver, IdTextBoxMessage, null);
            return TextBoxMessage;
        }

        public static IWebElement GetTextBoxSum1(ChromeDriver driver)
        {
            TextBoxSum1 = Helpers.GetWebElement(driver, IdTextBoxSum1, null);
            return TextBoxSum1;
        }

        public static IWebElement GetTextBoxSum2(ChromeDriver driver)
        {
            TextBoxSum2 = Helpers.GetWebElement(driver, IdTextBoxSum2, null);
            return TextBoxSum2;
        }

        public static IWebElement GetDisplayMessage(ChromeDriver driver)
        {
            DisplayMessage = Helpers.GetWebElement(driver, IdDisplayMessage, null);
            return DisplayMessage;
        }
        public static IWebElement GetDisplaySum(ChromeDriver driver)
        {
            DisplaySum = Helpers.GetWebElement(driver, IdDisplaySum, null);
            return DisplaySum;
        }
    }
}
