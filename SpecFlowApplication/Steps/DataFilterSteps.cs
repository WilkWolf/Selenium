using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.Table;
using SeleniumApplication.Shared;
using TechTalk.SpecFlow;

namespace SpecFlowApplication.Steps
{
    [Binding]
    public class DataFilterSteps
    {
        readonly PageObjectDataFilter _pageObject = new PageObjectDataFilter();
        private ChromeDriver _driver;

        [Given(@"I go page to table-records-filter-demo\.html page")]
        public void GivenIGoPageToTable_Records_Filter_Demo_HtmlPage()
        {
            _driver = Helpers.RunPage(_pageObject.PageUrl);
        }

        [Given(@"I want to see (.*) records")]
        public void GivenIWantToSeeRecords(int p0)
        {
            int numberOfRecords = ListOfElements(_pageObject.GetTable(_driver)).Count;

            Helpers.AssertTrue(_driver, numberOfRecords == p0, $"Number of records is not correct\nExpected:5\nCurrent:{numberOfRecords}", false);
        }

        [When(@"I click Green button")]
        public void WhenIClickGreenButton()
        {
           _pageObject.GetButtonGreen(_driver).Click();
        }

        [Then(@"I want to see two records with only green color")]
        public void ThenIWantToSeeTwoRecordsWithOnlyGreenColor()
        {
            var list = ListOfElements(_pageObject.GetTable(_driver));

            var displayedList = GetListOfDisplayedElements(list);
            bool isAllGreen = CheckIfAllElementsHasSameText(displayedList, "(Green)");

            Helpers.AssertTrue(_driver, isAllGreen, $"Not all elements are green", false);
        }

        [When(@"I click Orange button")]
        public void WhenIClickOrangeButton()
        {
            _pageObject.GetButtonOrange(_driver).Click();
        }

        [Then(@"I want to see two records with only orange color")]
        public void ThenIWantToSeeTwoRecordsWithOnlyOrangeColor()
        {
            var list = ListOfElements(_pageObject.GetTable(_driver));

            var displayedList = GetListOfDisplayedElements(list);
            bool isAllOrange = CheckIfAllElementsHasSameText(displayedList, "(Orange)");

            Helpers.AssertTrue(_driver, isAllOrange, $"Not all elements are orange", false);
        }

        [When(@"I click Red button")]
        public void WhenIClickRedButton()
        {
            _pageObject.GetButtonRed(_driver).Click();
        }

        [Then(@"I want to see one record with only red color")]
        public void ThenIWantToSeeOneRecordWithOnlyRedColor()
        {
            var list = ListOfElements(_pageObject.GetTable(_driver));

            var displayedList = GetListOfDisplayedElements(list);
            bool isAllRed = CheckIfAllElementsHasSameText(displayedList, "(Red)");

            Helpers.AssertTrue(_driver, isAllRed, $"Not all elements are red",false);
        }

        [When(@"I click All button")]
        public void WhenIClickAllButton()
        {
            _pageObject.GetButtonAll(_driver).Click();
            Thread.Sleep(500);
        }

        [Then(@"I want to see all records")]
        public void ThenIWantToSeeAllRecords()
        {
            var list = ListOfElements(_pageObject.GetTable(_driver));
            var displayedList = GetListOfDisplayedElements(list);
            int countOfDisplayedElements = displayedList.Count;

            Helpers.AssertTrue(_driver, countOfDisplayedElements == 5, $"Not all elements are displayed");
        }

        private IReadOnlyCollection<IWebElement> ListOfElements(IWebElement element)
        {
            return element.FindElements(By.TagName("tr"));
        }

        private bool CheckIfAllElementsHasSameText(ICollection<IWebElement> displayedList, string expectedText)
        {
            foreach (var element in displayedList)
            {
                var text = element.FindElement(By.TagName("h4")).FindElement(By.TagName("span")).Text;
                if (text != expectedText)
                {
                    return false;
                }
            }
            return true;
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

    }
}
