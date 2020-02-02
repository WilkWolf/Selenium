using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject
{
   public class PageObjectAjaxFormSubmit
    {
        public readonly string PageUrl = Helpers.GetValueFromSettings("..Page.Input.AjaxForm");

        public readonly string XPathNameLabel = "//*[@id='frm']/div[1]/label";
        public readonly string XPathNameInput = "//*[@id='title']";
        public readonly string XPathCommentLabel = "//*[@id='frm']/div[2]/label";
        public readonly string XPathCommentInput = "//*[@id='description']";
        public readonly string XPathSubmitButton = "//*[@id='btn-submit']";
        public readonly string XPathDisplayMessage = "//*[@id='submit-control']";
        public readonly string XPathAjaxIcon = "//*[@id='submit-control']/img";
        public readonly string XPathNameValidation = "//*[@id='frm']/div[1]/span";

        public IWebElement GetNameLabel(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathNameLabel);

        public IWebElement GetNameInput(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathNameInput);

        public IWebElement GetCommentLabel(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathCommentLabel);

        public IWebElement GetCommentInput(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathCommentInput);

        public IWebElement GetSubmitButton(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathSubmitButton);

        public IWebElement GetDisplayMessage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathDisplayMessage);

        public IWebElement GetAjaxIcon(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathAjaxIcon);

        public IWebElement GetNameValidation(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathNameValidation);
    }
}
