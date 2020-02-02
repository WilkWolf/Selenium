using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using SeleniumApplication.PageObject.Table;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Table
{
    public class TablePagination
    {
        private PageObjectTablePagination PageObjects = new PageObjectTablePagination();
        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);

            Assert.True(driver.Url == "https://www.seleniumeasy.com/test/table-pagination-demo.html", $"Page not exist \n Current:{driver.Url}\n Expected:https://www.seleniumeasy.com/test/table-pagination-demo.html");
            driver.Close();
        }

        [Fact]
        public void CheckCountOfRecords()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);
            IList<IWebElement> tableRows = PageObjects.GetTableBody(driver).FindElements(By.TagName("tr"));
            int countOfTableRows = tableRows.Count;

            Assert.True(countOfTableRows == 15,$"Table doesn't has expected number of row. Expected:15\nCurrent:{countOfTableRows}");
        }

        [Fact]
        public void IsPageButtonsExist()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);
            bool firstPage = PageObjects.GetFirstPage(driver).Displayed;
            bool secondPage = PageObjects.GetSecondPage(driver).Displayed;
            bool thirdPage = PageObjects.GetThirdPage(driver).Displayed;

            Assert.True(firstPage,"Button '1' not exist");
            Assert.True(secondPage, "Button '2' not exist");
            Assert.True(thirdPage, "Button '3' not exist");
        }

        [Fact]
        public void CheckDisplayedStatusOfNextPreviousButtonOnFirstPage()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);
            bool nextButton = PageObjects.GetNext(driver).Displayed;
            bool previousButton = PageObjects.GetPrevious(driver).Displayed;

            Assert.True(nextButton, "Button '>>' not exist");
            Assert.False(previousButton, "Button '<<' exist");
        }

        [Fact]
        public void CheckDisplayedStatusOfNextPreviousButtonOnSecondPage()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);
            PageObjects.GetSecondPage(driver).Click();
            bool nextButton = PageObjects.GetNext(driver).Displayed;
            bool previousButton = PageObjects.GetPrevious(driver).Displayed;

            Assert.True(nextButton, "Button '>>' not exist");
            Assert.True(previousButton, "Button '<<' not exist");
        }

        [Fact]
        public void CheckDisplayedStatusOfNextPreviousButtonOnThirdPage()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);
            PageObjects.GetThirdPage(driver).Click();
            bool nextButton = PageObjects.GetNext(driver).Displayed;
            bool previousButton = PageObjects.GetPrevious(driver).Displayed;

            Assert.False(nextButton, "Button '>>'  exist");
            Assert.True(previousButton, "Button '<<' not exist");
        }
    }
}
