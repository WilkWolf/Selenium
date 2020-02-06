
using System.Threading;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.AlertsAndModals;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.AlertsAndModals
{
    public class BootstrapAlerts
    {
        private readonly PageObjectBootstrapAlerts _pageObjects = new PageObjectBootstrapAlerts();

        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);
            string url = driver.Url;

            Helpers.AssertTrue(driver, url == "https://www.seleniumeasy.com/test/bootstrap-alert-messages-demo.html", $"Page not exist \n Current:{driver.Url}\n Expected:https://www.seleniumeasy.com/test/bootstrap-alert-messages-demo.html");
           //  Helpers.AssertTrue(driver, url == "https://www.seleniumeasy.com/test/bootstrap-alert-messages-demo.html", $"Page not exist \n Current:{driver.Url}\n Expected:https://www.seleniumeasy.com/test/bootstrap-alert-messages-demo.html");
        }

        [Theory]
        [InlineData("AutocloseableSuccess", PageObjectBootstrapAlerts.XPathButtonAutocloseableSuccesMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableSuccesMessage)]
        [InlineData("AutocloseableDanger", PageObjectBootstrapAlerts.XPathButtonAutocloseableDangerMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableDangerMessage)]
        [InlineData("AutocloseableWarning", PageObjectBootstrapAlerts.XPathButtonAutocloseableWarningMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableWarningMessage)]
        [InlineData("AutocloseableInfo", PageObjectBootstrapAlerts.XPathButtonAutocloseableInfoMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableInfoMessage)]
        [InlineData("NormalSuccess", PageObjectBootstrapAlerts.XPathButtonNormalSuccessMessage, PageObjectBootstrapAlerts.XPathAlertsNormalSuccessMessage)]
        [InlineData("NormalDanger", PageObjectBootstrapAlerts.XPathButtonNormalDangerMessage, PageObjectBootstrapAlerts.XPathAlertsNormalDangerMessage)]
        [InlineData("NormalWarnin", PageObjectBootstrapAlerts.XPathButtonNormalWarningMessage, PageObjectBootstrapAlerts.XPathAlertsNormalWarningMessage)]
        [InlineData("NormalInfo", PageObjectBootstrapAlerts.XPathButtonNormalInfoMessage, PageObjectBootstrapAlerts.XPathAlertsNormalInfoMessage)]
        public void CheckIfMessageDisplay(string alertName, string xPathButton, string xPathAlert)
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            Helpers.GetWebElement(driver, xPathButton).Click();
            bool isElementDisplayed = Helpers.GetWebElement(driver, xPathAlert).Displayed;

            Helpers.AssertTrue(driver, isElementDisplayed, $"Alerts {alertName} is not displayed");
        }

        [Theory]
        [InlineData("AutocloseableSuccess",5, PageObjectBootstrapAlerts.XPathButtonAutocloseableSuccesMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableSuccesMessage)]
        [InlineData("AutocloseableDanger",5, PageObjectBootstrapAlerts.XPathButtonAutocloseableDangerMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableDangerMessage)]
        [InlineData("AutocloseableWarning",3, PageObjectBootstrapAlerts.XPathButtonAutocloseableWarningMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableWarningMessage)]
        [InlineData("AutocloseableInfo",6, PageObjectBootstrapAlerts.XPathButtonAutocloseableInfoMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableInfoMessage)]
        public void CheckAutocloseableAlertsClose(string alertName, int visibilityTimeInSecond, string xPathButton, string xPathAlert)
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);


            int visibilityTimeInHalfSecond = visibilityTimeInSecond * 2;
            int counterOfWaitLoop = 1;
            bool isTimeOfVisibilityCorrect = false;

            Helpers.GetWebElement(driver, xPathButton).Click();
            while (counterOfWaitLoop <= 20)
            {
                Thread.Sleep(500);

                // jezeli alert nie jest wyswietlony i nie uplynął wymagany czas to przerywa i zwraca false 
                if (!Helpers.GetWebElement(driver, xPathAlert).Displayed && visibilityTimeInHalfSecond > counterOfWaitLoop)
                {
                    isTimeOfVisibilityCorrect = false;
                    break;
                }
                // jezeli alert jest wyswieylony po uplynieciu wymaganego czasu to przerywa i zwraca false 
                else if ((Helpers.GetWebElement(driver, xPathAlert).Displayed && visibilityTimeInHalfSecond < counterOfWaitLoop) || visibilityTimeInHalfSecond < counterOfWaitLoop)
                {
                    isTimeOfVisibilityCorrect = false;
                    break;
                }// jeżeli alert nie jest widoczny i czas równa się przebiegowi pętli to zwróć true
                else if (!Helpers.GetWebElement(driver, xPathAlert).Displayed && visibilityTimeInHalfSecond == counterOfWaitLoop)
                {
                    isTimeOfVisibilityCorrect = true;
                    break;
                }
                counterOfWaitLoop++;
            }

             Helpers.AssertTrue(driver, isTimeOfVisibilityCorrect, $"Alerts {alertName} is not correct displayed for {visibilityTimeInSecond} seconds. Current time is:{counterOfWaitLoop} of half seconds");
        }

        [Theory]
        [InlineData("AutocloseableSuccess", PageObjectBootstrapAlerts.XPathButtonAutocloseableSuccesMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableSuccesMessage)]
        [InlineData("AutocloseableDanger", PageObjectBootstrapAlerts.XPathButtonAutocloseableDangerMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableDangerMessage)]
        [InlineData("AutocloseableWarning", PageObjectBootstrapAlerts.XPathButtonAutocloseableWarningMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableWarningMessage)]
        [InlineData("AutocloseableInfo", PageObjectBootstrapAlerts.XPathButtonAutocloseableInfoMessage, PageObjectBootstrapAlerts.XPathAlertsAutocloseableInfoMessage)]
        public void CheckIfButtonIsDisabledWhenClickOnAoutcloseableButton(string alertName, string xPathButton, string xPathAlert)
        {
            ChromeDriver driver = Helpers.RunPage(_pageObjects.PageUrl);

            Helpers.GetWebElement(driver, xPathButton).Click();
            bool isDisabled = Helpers.GetWebElement(driver, xPathButton).Enabled;

            Helpers.AssertFalse(driver,isDisabled, $"Button {alertName} is enabled when should be disabled.");
        }
    }
}
