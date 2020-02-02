using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject.Table
{
   public class PageObjectTablePagination
    {
        public readonly string PageUrl = Helpers.GetValueFromSettings("..Page.Table.TablePagination");

        public readonly string XPathTable = "/html/body/div[2]/div/div[2]/section/div/table";
        public readonly string XPathTableBody = "//*[@id='myTable']";
        public readonly string XPathPrevious = "//*[@id='myPager']/li[1]/a";
        public readonly string XPathNext = "//*[@id='myPager']/li[5]/a";
        public readonly string XPathFirstPage = "//*[@id='myPager']/li[2]/a";
        public readonly string XPathSecondPage = "//*[@id='myPager']/li[3]/a";
        public readonly string XPathThirdPage = "//*[@id='myPager']/li[4]/a";

        public IWebElement GetTable(ChromeDriver driver) => Helpers.GetWebElement(driver,XPathTable);
        public IWebElement GetPrevious(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathPrevious);
        public IWebElement GetNext(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathNext);
        public IWebElement GetFirstPage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathFirstPage);
        public IWebElement GetSecondPage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathSecondPage);
        public IWebElement GetThirdPage(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathThirdPage);
        public IWebElement GetTableBody(ChromeDriver driver) => Helpers.GetWebElement(driver, XPathTableBody);

    }
}
