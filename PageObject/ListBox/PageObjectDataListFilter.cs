using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject.ListBox
{
   public  class PageObjectDataListFilter
    {
        public readonly string PageUrl = Helpers.GetValueFromSettings("..Page.ListBox.DataListFilter");

   }
}
