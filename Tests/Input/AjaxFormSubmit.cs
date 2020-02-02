using System.Threading;
using Newtonsoft.Json.Bson;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject;
using SeleniumApplication.Shared;
using Xunit;

namespace SeleniumApplication.Tests.Input
{
    public class AjaxFormSubmit
    {
        private readonly PageObjectAjaxFormSubmit PageObjects = new PageObjectAjaxFormSubmit();

        [Fact]
        public void CheckUrl()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);

            Assert.True(driver.Url == "https://www.seleniumeasy.com/test/ajax-form-submit-demo.html", $"Page not exist \n Current:{driver.Url}\n Expected:https://www.seleniumeasy.com/test/basic-radiobutton-demo.html ");
            driver.Close();
        }

        [Fact]
        public void SubmitEmptyForm()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);
            bool isSubmitButtonHidden = PageObjects.GetSubmitButton(driver).Displayed;

            PageObjects.GetSubmitButton(driver).Click();
            bool isValidationDisplayed =  PageObjects.GetNameValidation(driver).Displayed;
            Assert.True(isValidationDisplayed, "Validations is not displayed");
            Assert.True(isSubmitButtonHidden, "Button is not displayed");
        }

        [Fact]
        public void SubmitFilledForm()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);

            Helpers.WriteText(PageObjects.GetNameInput(driver),"Test Name");
            Helpers.WriteText(PageObjects.GetCommentInput(driver),"Test Comment");
            bool isSubmitButtonHidden = PageObjects.GetSubmitButton(driver).Displayed;

            PageObjects.GetSubmitButton(driver).Click();

            bool isValidationDisplayed = PageObjects.GetNameValidation(driver).Displayed;

            Assert.False(isValidationDisplayed, "Validations is  displayed");
            Assert.True(isSubmitButtonHidden, "Button is displayed");
        }

        [Fact]
        public void AjaxMessage()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);
            string expectedMessage = "Ajax Request is Processing!";

            Helpers.WriteText(PageObjects.GetNameInput(driver), "Test Name");
            PageObjects.GetSubmitButton(driver).Click();

            string message = PageObjects.GetDisplayMessage(driver).Text;

            Assert.True(expectedMessage == message,$"Message is not valid.\nExpected:{expectedMessage}\nCurrent:{message}");
        }

        [Fact]
        public void DisplayedMessage()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);
            string expectedMessage = "Form submited Successfully!";

            Helpers.WriteText(PageObjects.GetNameInput(driver), "Test Name");
            PageObjects.GetSubmitButton(driver).Click();

            string message = WaitForCorrectResponse(driver, expectedMessage);

            Assert.True(expectedMessage == message, $"Message is not valid.\nExpected:{expectedMessage}\nCurrent:{message}");
        }

        [Fact]
        public void DisplayedAjaxIcon()
        {
            ChromeDriver driver = Helpers.RunPage(PageObjects.PageUrl);

            Helpers.WriteText(PageObjects.GetNameInput(driver), "Test Name");
            PageObjects.GetSubmitButton(driver).Click();
            Thread.Sleep(400);
            bool isIconDisplayed = PageObjects.GetAjaxIcon(driver).Displayed;

            Assert.True(isIconDisplayed,$"Ajax icon is not displayed.");
        }

        private string WaitForCorrectResponse(ChromeDriver driver, string expectedMessage)
        {
            int waitCounter = 0;
            string message = null;

            while (waitCounter < 4)
            {
                message = PageObjects.GetDisplayMessage(driver).Text;
                if (message == expectedMessage)
                {
                    break;
                }
                ++waitCounter;
                Thread.Sleep(500);
            }
            return message;
        }
    }
}



