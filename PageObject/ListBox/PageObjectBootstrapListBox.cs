﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject.ListBox
{
   public class PageObjectBootstrapListBox
    {
        public readonly string PageUrl = Helpers.GetValueFromSettings("..Page.ListBox.BootstrapListBox");

        public readonly string XPathLeftSearchBox = "//*[@id='listhead']/div[1]/div/input";
        public readonly string XPathRightSearchBox = "//*[@id='listhead']/div[2]/div/input";
        public readonly string XPathLeftButtonsSelectAll = "//*[@id='listhead']/div[2]/div/a";
        public readonly string XPathRightButtonSelectAll = "//*[@id='listhead']/div[1]/div/a";
        public readonly string XPathButtonSendElementsToRightListBox = "/html/body/div[2]/div/div[2]/div/div[2]/button[2]";
        public readonly string XPathButtonSendElementsToLeftListBox = "/html/body/div[2]/div/div[2]/div/div[2]/button[1]";
        public readonly string XPathLeftListBox = "/html/body/div[2]/div/div[2]/div/div[1]/div/ul";
        public readonly string XPathRightListBox = "/html/body/div[2]/div/div[2]/div/div[3]/div/ul";

        public IWebElement GetLeftSearchBox(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathLeftSearchBox);
        public IWebElement GetRightSearchBox(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathRightSearchBox);
        public IWebElement GetLeftButtonsSelectAll(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathLeftButtonsSelectAll);
        public IWebElement GetRightButtonSelectAll(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathRightButtonSelectAll);
        public IWebElement GetButtonSendElementsToRightListBox(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonSendElementsToRightListBox);
        public IWebElement GetButtonSendElementsToLeftListBox(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathButtonSendElementsToLeftListBox);
        public IWebElement GetLeftListBox(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathLeftListBox);
        public IWebElement GetRightListBox(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathRightListBox);

    }
}
