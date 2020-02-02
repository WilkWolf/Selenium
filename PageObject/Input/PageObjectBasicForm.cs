﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject.Input
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

        public static IWebElement GetButtonSubmitMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonSubmitMessage);

        public static IWebElement GetButtonSubmitSum(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonSubmitSum);

        public static IWebElement GetTextBoxMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathTextBoxMessage);

        public static IWebElement GetTextBoxSum1(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathTextBoxSum1);

        public static IWebElement GetTextBoxSum2(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathTextBoxSum2);

        public static IWebElement GetDisplayMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathDisplayMessage);

        public static IWebElement GetDisplaySum(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathDisplaySum);
    }
}
