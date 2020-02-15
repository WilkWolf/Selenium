using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.Table;
using SeleniumApplication.Shared;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowApplication.Steps
{
    [Binding]
    public class TablePaginationSteps
    {
        readonly PageObjectTablePagination _pageObject = new PageObjectTablePagination();
        private ChromeDriver _driver;

        [Given(@"Go to table-pagination-demo page")]
        public void GivenGoToTable_Pagination_DemoPage()
        {
            _driver = Helpers.RunPage(_pageObject.PageUrl);
        }

        [When(@"I am on the first page")]
        public void WhenIAmOnTheFirstPage()
        {
            _pageObject.GetFirstPage(_driver).Click();
        }

        [When(@"I am check if there is 5 record on first page")]
        public void WhenIamCheckIfThereIs5RecordOnFirstPage()
        {
            ICollection<IWebElement> tableRows = FindAllButton();
            int countOfTableRows = tableRows.Count;
            Helpers.AssertTrue(_driver,countOfTableRows == 5, "Number of records  on first page is not correct", false);
        }

        [Then(@"Go to second Page")]
        public void ThenGoToSecondPage()
        {
            _pageObject.GetSecondPage(_driver).Click();
        }

        [When(@"I am check if there is 5 record on second page")]
        public void WhenIamCheckIfThereIs5RecordOnSecondPage()
        {
            ICollection<IWebElement> tableRows = FindAllButton();
            int countOfTableRows = tableRows.Count;
           Helpers.AssertTrue(_driver, countOfTableRows == 5, "Number of records on second page is not correct", false);
            
        }


        [Then(@"Go to third Page")]
        public void ThenGoToThirdPage()
        {

            _pageObject.GetThirdPage(_driver).Click();
        }

        [When(@"I am check if there is 5 record on third page")]
        public void WhenIAmCheckIfThereIs5RecordOnThirdPage()
        {
            ICollection<IWebElement> tableRows = FindAllButton();
            int countOfTableRows = tableRows.Count;
            Helpers.AssertTrue(_driver, countOfTableRows == 5, "Number of records on third page is not correct");
        }

        private ICollection<IWebElement> GetListOfDisplayedElements(IReadOnlyCollection<IWebElement> list)
        {
            ICollection<IWebElement> displayedList = new List<IWebElement>();

            foreach (var element in list)
            {
                if (element.Displayed)
                {
                    displayedList.Add(element);
                }
            }
            return displayedList;
        }

        private ICollection<IWebElement> FindAllButton()
        {
            ICollection<IWebElement> displayedList = new List<IWebElement>();
            var listOfElement =  _driver.FindElementsByTagName("tr");

            foreach (var element in listOfElement)
            {
                var aaa = element.GetAttribute("style");
                var aaass = element.GetAttribute("class");

                if (element.GetAttribute("style") == "display: table-row;")
                {
                    displayedList.Add(element);
                }
            }
            return displayedList;
        }



    }
}
