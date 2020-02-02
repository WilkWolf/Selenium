using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.ListBox;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.ListBox
{
   public class BootstrapListBox
    {
        private readonly PageObjectBootstrapListBox PageObjects = new PageObjectBootstrapListBox();

        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);

            Assert.True(driver.Url == "https://www.seleniumeasy.com/test/bootstrap-dual-list-box-demo.html", $"Page not exist \n Current:{driver.Url}\n Expected:https://www.seleniumeasy.com/test/bootstrap-dual-list-box-demo.html");
            driver.Close();
        }

        [Fact]
        public void SendSingleElementToRightListbox()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);
            int leftMenuElementsCountBefore = PageObjects.GetLeftListBox(driver).FindElements(By.TagName("li")).Count;
            int rightMenuElementsCounBefore = PageObjects.GetRightListBox(driver).FindElements(By.TagName("li")).Count;

            PageObjects.GetLeftListBox(driver).FindElement(By.XPath(".//li")).Click();
            PageObjects.GetButtonSendElementsToRightListBox(driver).Click();

            int leftMenuElementsCountAfter = PageObjects.GetLeftListBox(driver).FindElements(By.TagName("li")).Count;
            int rightMenuElementsCountAfter = PageObjects.GetRightListBox(driver).FindElements(By.TagName("li")).Count;

            Assert.True(leftMenuElementsCountBefore == leftMenuElementsCountAfter + 1);
            Assert.True(rightMenuElementsCounBefore == rightMenuElementsCountAfter - 1);
        }

        [Fact]
        public void SendSingleElementToLeftListbox()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);
            int leftMenuElementsCountBefore = PageObjects.GetLeftListBox(driver).FindElements(By.TagName("li")).Count;
            int rightMenuElementsCounBefore = PageObjects.GetRightListBox(driver).FindElements(By.TagName("li")).Count;

            PageObjects.GetRightListBox(driver).FindElement(By.XPath(".//li")).Click();
            PageObjects.GetButtonSendElementsToLeftListBox(driver).Click();

            int leftMenuElementsCountAfter = PageObjects.GetLeftListBox(driver).FindElements(By.TagName("li")).Count;
            int rightMenuElementsCountAfter = PageObjects.GetRightListBox(driver).FindElements(By.TagName("li")).Count;

            Assert.True(leftMenuElementsCountBefore == leftMenuElementsCountAfter - 1);
            Assert.True(rightMenuElementsCounBefore == rightMenuElementsCountAfter + 1);
        }

        [Fact]
        public void SendAllElementToRightListBox()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);

            int leftMenuElementsCountBefore = PageObjects.GetLeftListBox(driver).FindElements(By.TagName("li")).Count;
            int rightMenuElementsCounBefore = PageObjects.GetRightListBox(driver).FindElements(By.TagName("li")).Count;

            PageObjects.GetLeftButtonsSelectAll(driver).Click();
            PageObjects.GetButtonSendElementsToRightListBox(driver).Click();

            int leftMenuElementsCountAfter = PageObjects.GetLeftListBox(driver).FindElements(By.TagName("li")).Count;
            int rightMenuElementsCountAfter = PageObjects.GetRightListBox(driver).FindElements(By.TagName("li")).Count;

            Assert.True(leftMenuElementsCountAfter == 0);
            Assert.True(rightMenuElementsCountAfter == leftMenuElementsCountBefore + rightMenuElementsCounBefore);
        }

        [Fact]
        public void SendAllElementToLeftListBox()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);

            int leftMenuElementsCountBefore = PageObjects.GetLeftListBox(driver).FindElements(By.TagName("li")).Count;
            int rightMenuElementsCounBefore = PageObjects.GetRightListBox(driver).FindElements(By.TagName("li")).Count;

            PageObjects.GetRightButtonSelectAll(driver).Click();
            PageObjects.GetButtonSendElementsToLeftListBox(driver).Click();

            int leftMenuElementsCountAfter = PageObjects.GetLeftListBox(driver).FindElements(By.TagName("li")).Count;
            int rightMenuElementsCountAfter = PageObjects.GetRightListBox(driver).FindElements(By.TagName("li")).Count;

            Assert.True(rightMenuElementsCountAfter == 0);
            Assert.True(leftMenuElementsCountAfter == leftMenuElementsCountBefore + rightMenuElementsCounBefore);
        }

        [Fact]
        public void FilterCheckShowSingleValueOfLeft()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);

            Helpers.WriteText(PageObjects.GetLeftSearchBox(driver),"bootstrap-duallist");
            ReadOnlyCollection<IWebElement> listOfElements = PageObjects.GetLeftListBox(driver).FindElements(By.CssSelector("li"));

          int counterOfDisplayedElement = CounterOfDisplayedElement(listOfElements);

            Assert.True(counterOfDisplayedElement == 1, $"There is not correct number of displayed elements.\nExpected:1\nCurren:{counterOfDisplayedElement}");
        }

        [Fact]
        public void FilterCheckShowSingleValueOfRight()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);

            Helpers.WriteText(PageObjects.GetRightSearchBox(driver), "Cras justo odio");
            ReadOnlyCollection<IWebElement> listOfElements = PageObjects.GetRightListBox(driver).FindElements(By.CssSelector("li"));

            int counterOfDisplayedElement = CounterOfDisplayedElement(listOfElements);

            Assert.True(counterOfDisplayedElement == 1, $"There is not correct number of displayed elements.\nExpected:1\nCurren:{counterOfDisplayedElement}");
        }
        [Fact]
        public void SendElementWhichWasFilteredToRightListBox()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);
            int leftMenuElementsCountBefore = PageObjects.GetLeftListBox(driver).FindElements(By.TagName("li")).Count;
            int rightMenuElementsCountBefore = PageObjects.GetRightListBox(driver).FindElements(By.TagName("li")).Count;
            int sumOfElement = leftMenuElementsCountBefore + rightMenuElementsCountBefore;

            PageObjects.GetLeftButtonsSelectAll(driver).Click();
            Helpers.WriteText(PageObjects.GetLeftSearchBox(driver), "1");
            PageObjects.GetButtonSendElementsToRightListBox(driver).Click();

            int leftMenuElementsCount = PageObjects.GetLeftListBox(driver).FindElements(By.TagName("li")).Count;
            int rightMenuElementsCount = PageObjects.GetRightListBox(driver).FindElements(By.TagName("li")).Count;

            ReadOnlyCollection<IWebElement> listOfElements = PageObjects.GetRightListBox(driver).FindElements(By.CssSelector("li"));
            int counterOfDisplayedElement = CounterOfDisplayedElement(listOfElements);

           Assert.True(leftMenuElementsCount == 0, $"Value of left listBox elements is not correct.\nExpected:0\nCurrent:{leftMenuElementsCount}");
           Assert.True(leftMenuElementsCountBefore + leftMenuElementsCountBefore == rightMenuElementsCount, $"Value of right listBox elements is not correct.\nExpected:{sumOfElement}\nCurrent:{rightMenuElementsCount}");
           Assert.True(counterOfDisplayedElement == rightMenuElementsCount, $"Value of displayed elements is not correct. \nExpected:{rightMenuElementsCount}\nCurrent:{counterOfDisplayedElement}");
        }

        [Fact]
        public void SendElementWhichWasFilteredToLeftListBox()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);
            int leftMenuElementsCountBefore = PageObjects.GetLeftListBox(driver).FindElements(By.TagName("li")).Count;
            int rightMenuElementsCountBefore = PageObjects.GetRightListBox(driver).FindElements(By.TagName("li")).Count;
            int sumOfElement = leftMenuElementsCountBefore + rightMenuElementsCountBefore;

            PageObjects.GetRightButtonSelectAll(driver).Click();
            Helpers.WriteText(PageObjects.GetRightSearchBox(driver), "1");
            PageObjects.GetButtonSendElementsToLeftListBox(driver).Click();

            int leftMenuElementsCount = PageObjects.GetLeftListBox(driver).FindElements(By.TagName("li")).Count;
            int rightMenuElementsCount = PageObjects.GetRightListBox(driver).FindElements(By.TagName("li")).Count;

            ReadOnlyCollection<IWebElement> listOfElements = PageObjects.GetLeftListBox(driver).FindElements(By.CssSelector("li"));
            int counterOfDisplayedElement = CounterOfDisplayedElement(listOfElements);

            Assert.True(rightMenuElementsCount == 0, $"Value of right listBox elements is not correct.\nExpected:0\nCurrent:{rightMenuElementsCount}");
            Assert.True(leftMenuElementsCountBefore + leftMenuElementsCountBefore == leftMenuElementsCount, $"Value of left listBox elements is not correct.\nExpected:{sumOfElement}\nCurrent:{rightMenuElementsCount}");
            Assert.True(counterOfDisplayedElement == leftMenuElementsCount, $"Value of displayed elements is not correct. \nExpected:{leftMenuElementsCount}\nCurrent:{counterOfDisplayedElement}");
        }
        [Fact]
        public void ClickSendWhenNonElementWasSelected()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);
            int leftMenuElementsCountBefore = PageObjects.GetLeftListBox(driver).FindElements(By.TagName("li")).Count;
            int rightMenuElementsCountBefore = PageObjects.GetRightListBox(driver).FindElements(By.TagName("li")).Count;
            PageObjects.GetButtonSendElementsToRightListBox(driver).Click();
            int leftMenuElementsCountAfter = PageObjects.GetLeftListBox(driver).FindElements(By.TagName("li")).Count;
            int rightMenuElementsCountAfter = PageObjects.GetRightListBox(driver).FindElements(By.TagName("li")).Count;

            Assert.True(leftMenuElementsCountBefore == leftMenuElementsCountAfter, $"Value is not correct.\nExpected:{leftMenuElementsCountBefore}\nCurrent:{leftMenuElementsCountAfter}");
            Assert.True(rightMenuElementsCountBefore == rightMenuElementsCountAfter, $"Value is not correct.\nExpected:{rightMenuElementsCountBefore}\nCurrent:{rightMenuElementsCountAfter}");
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
