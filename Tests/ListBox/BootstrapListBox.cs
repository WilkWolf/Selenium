﻿using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.ListBox;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.ListBox
{
    public class BootstrapListBox
    {
        private readonly PageObjectBootstrapListBox _pageObjects = new PageObjectBootstrapListBox();

        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            string url = driver.Url;
            driver.Quit();
            Assert.True(url == "https://www.seleniumeasy.com/test/bootstrap-dual-list-box-demo.html", $"Page not exist \n Current:{driver.Url}\n Expected:https://www.seleniumeasy.com/test/bootstrap-dual-list-box-demo.html");
        }

        [Fact]
        public void SendSingleElementToRightListbox()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            int leftMenuElementsCountBefore = GetCountOfElementList(_pageObjects.GetLeftListBox(driver));
            int rightMenuElementsCountBefore = GetCountOfElementList(_pageObjects.GetRightListBox(driver));

            _pageObjects.GetLeftListBox(driver).FindElement(By.XPath(".//li")).Click();
            _pageObjects.GetButtonSendElementsToRightListBox(driver).Click();

            int leftMenuElementsCountAfter = GetCountOfElementList(_pageObjects.GetLeftListBox(driver));
            int rightMenuElementsCountAfter = GetCountOfElementList(_pageObjects.GetRightListBox(driver));

            driver.Quit();
            Assert.True(leftMenuElementsCountBefore == leftMenuElementsCountAfter + 1);
            Assert.True(rightMenuElementsCountBefore == rightMenuElementsCountAfter - 1);
        }

        [Fact]
        public void SendSingleElementToLeftListbox()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            int leftMenuElementsCountBefore = GetCountOfElementList(_pageObjects.GetLeftListBox(driver));
            int rightMenuElementsCountBefore = GetCountOfElementList(_pageObjects.GetRightListBox(driver));

            _pageObjects.GetRightListBox(driver).FindElement(By.XPath(".//li")).Click();
            _pageObjects.GetButtonSendElementsToLeftListBox(driver).Click();

            int leftMenuElementsCountAfter = GetCountOfElementList(_pageObjects.GetLeftListBox(driver));
            int rightMenuElementsCountAfter = GetCountOfElementList(_pageObjects.GetRightListBox(driver));

            driver.Quit();
            Assert.True(leftMenuElementsCountBefore == leftMenuElementsCountAfter - 1);
            Assert.True(rightMenuElementsCountBefore == rightMenuElementsCountAfter + 1);
        }

        [Fact]
        public void SendAllElementToRightListBox()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            int leftMenuElementsCountBefore = GetCountOfElementList(_pageObjects.GetLeftListBox(driver));
            int rightMenuElementsCounBefore = GetCountOfElementList(_pageObjects.GetRightListBox(driver));

            _pageObjects.GetLeftButtonsSelectAll(driver).Click();
            _pageObjects.GetButtonSendElementsToRightListBox(driver).Click();

            int leftMenuElementsCountAfter = GetCountOfElementList(_pageObjects.GetLeftListBox(driver));
            int rightMenuElementsCountAfter = GetCountOfElementList(_pageObjects.GetRightListBox(driver));

            driver.Quit();
            Assert.True(leftMenuElementsCountAfter == 0);
            Assert.True(rightMenuElementsCountAfter == leftMenuElementsCountBefore + rightMenuElementsCounBefore);
        }

        [Fact]
        public void SendAllElementToLeftListBox()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            int leftMenuElementsCountBefore = GetCountOfElementList(_pageObjects.GetLeftListBox(driver));
            int rightMenuElementsCounBefore = GetCountOfElementList(_pageObjects.GetRightListBox(driver));

            _pageObjects.GetRightButtonSelectAll(driver).Click();
            _pageObjects.GetButtonSendElementsToLeftListBox(driver).Click();

            int leftMenuElementsCountAfter = GetCountOfElementList(_pageObjects.GetLeftListBox(driver));
            int rightMenuElementsCountAfter = GetCountOfElementList(_pageObjects.GetRightListBox(driver));

            driver.Quit();
            Assert.True(rightMenuElementsCountAfter == 0);
            Assert.True(leftMenuElementsCountAfter == leftMenuElementsCountBefore + rightMenuElementsCounBefore);
        }

        [Fact]
        public void FilterCheckShowSingleValueOfLeft()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            Helpers.WriteText(_pageObjects.GetLeftSearchBox(driver), "bootstrap-duallist");
            ReadOnlyCollection<IWebElement> listOfElements = _pageObjects.GetLeftListBox(driver).FindElements(By.CssSelector("li"));

            int counterOfDisplayedElement = CounterOfDisplayedElement(listOfElements);

            driver.Quit();
            Assert.True(counterOfDisplayedElement == 1, $"There is not correct number of displayed elements.\nExpected:1\nCurren:{counterOfDisplayedElement}");
        }

        [Fact]
        public void FilterCheckShowSingleValueOfRight()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            Helpers.WriteText(_pageObjects.GetRightSearchBox(driver), "Cras justo odio");
            ReadOnlyCollection<IWebElement> listOfElements = _pageObjects.GetRightListBox(driver).FindElements(By.CssSelector("li"));

            int counterOfDisplayedElement = CounterOfDisplayedElement(listOfElements);

            driver.Quit();
            Assert.True(counterOfDisplayedElement == 1, $"There is not correct number of displayed elements.\nExpected:1\nCurren:{counterOfDisplayedElement}");
        }

        [Fact]
        public void SendElementWhichWasFilteredToRightListBox()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            int leftMenuElementsCountBefore = GetCountOfElementList(_pageObjects.GetLeftListBox(driver));
            int rightMenuElementsCountBefore = GetCountOfElementList(_pageObjects.GetRightListBox(driver));
            int sumOfElement = leftMenuElementsCountBefore + rightMenuElementsCountBefore;

            _pageObjects.GetLeftButtonsSelectAll(driver).Click();
            Helpers.WriteText(_pageObjects.GetLeftSearchBox(driver), "1");
            _pageObjects.GetButtonSendElementsToRightListBox(driver).Click();

            int leftMenuElementsCount = GetCountOfElementList(_pageObjects.GetLeftListBox(driver));
            int rightMenuElementsCount = GetCountOfElementList(_pageObjects.GetRightListBox(driver));

            ReadOnlyCollection<IWebElement> listOfElements = _pageObjects.GetRightListBox(driver).FindElements(By.CssSelector("li"));
            int counterOfDisplayedElement = CounterOfDisplayedElement(listOfElements);

            driver.Quit();
            Assert.True(leftMenuElementsCount == 0, $"Value of left listBox elements is not correct.\nExpected:0\nCurrent:{leftMenuElementsCount}");
            Assert.True(leftMenuElementsCountBefore + leftMenuElementsCountBefore == rightMenuElementsCount, $"Value of right listBox elements is not correct.\nExpected:{sumOfElement}\nCurrent:{rightMenuElementsCount}");
            Assert.True(counterOfDisplayedElement == rightMenuElementsCount, $"Value of displayed elements is not correct. \nExpected:{rightMenuElementsCount}\nCurrent:{counterOfDisplayedElement}");
        }

        [Fact]
        public void SendElementWhichWasFilteredToLeftListBox()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            int leftMenuElementsCountBefore = GetCountOfElementList(_pageObjects.GetLeftListBox(driver));
            int rightMenuElementsCountBefore = GetCountOfElementList(_pageObjects.GetRightListBox(driver));
            int sumOfElement = leftMenuElementsCountBefore + rightMenuElementsCountBefore;

            _pageObjects.GetRightButtonSelectAll(driver).Click();
            Helpers.WriteText(_pageObjects.GetRightSearchBox(driver), "1");
            _pageObjects.GetButtonSendElementsToLeftListBox(driver).Click();

            int leftMenuElementsCount = GetCountOfElementList(_pageObjects.GetLeftListBox(driver));
            int rightMenuElementsCount = GetCountOfElementList(_pageObjects.GetRightListBox(driver));

            ReadOnlyCollection<IWebElement> listOfElements = _pageObjects.GetLeftListBox(driver).FindElements(By.CssSelector("li"));
            int counterOfDisplayedElement = CounterOfDisplayedElement(listOfElements);

            driver.Quit();
            Assert.True(rightMenuElementsCount == 0, $"Value of right listBox elements is not correct.\nExpected:0\nCurrent:{rightMenuElementsCount}");
            Assert.True(leftMenuElementsCountBefore + leftMenuElementsCountBefore == leftMenuElementsCount, $"Value of left listBox elements is not correct.\nExpected:{sumOfElement}\nCurrent:{rightMenuElementsCount}");
            Assert.True(counterOfDisplayedElement == leftMenuElementsCount, $"Value of displayed elements is not correct. \nExpected:{leftMenuElementsCount}\nCurrent:{counterOfDisplayedElement}");
        }
        [Fact]
        public void ClickSendWhenNonElementWasSelected()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            int leftMenuElementsCountBefore = GetCountOfElementList(_pageObjects.GetLeftListBox(driver));
            int rightMenuElementsCountBefore = GetCountOfElementList(_pageObjects.GetRightListBox(driver));
            _pageObjects.GetButtonSendElementsToRightListBox(driver).Click();
            int leftMenuElementsCountAfter = GetCountOfElementList(_pageObjects.GetLeftListBox(driver));
            int rightMenuElementsCountAfter = GetCountOfElementList(_pageObjects.GetRightListBox(driver));

            driver.Quit();
            Assert.True(leftMenuElementsCountBefore == leftMenuElementsCountAfter, $"Value is not correct.\nExpected:{leftMenuElementsCountBefore}\nCurrent:{leftMenuElementsCountAfter}");
            Assert.True(rightMenuElementsCountBefore == rightMenuElementsCountAfter, $"Value is not correct.\nExpected:{rightMenuElementsCountBefore}\nCurrent:{rightMenuElementsCountAfter}");
        }


        private int GetCountOfElementList(IWebElement element)
        {
            return element.FindElements(By.TagName("li")).Count;
        }

        private static int CounterOfDisplayedElement(ReadOnlyCollection<IWebElement> listOfElements)
        {
            int counterOfDisplayedElement = listOfElements.Count;
            foreach (var element in listOfElements)
            {
                if (!element.Displayed)
                    counterOfDisplayedElement--;
            }
            return counterOfDisplayedElement;
        }
    }
}
