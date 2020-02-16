using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.Input;
using SeleniumApplication.Shared;
using TechTalk.SpecFlow;

namespace SpecFlowApplication.Steps
{
    [Binding]
    public class BasicFormSteps
    {
        [Binding]
        public class SimpleFormSteps
        {
            readonly PageObjectBasicForm _pageObject = new PageObjectBasicForm();
            private ChromeDriver _driver;

            [Given(@"I enter to /test/basic-first-form-demo page")]
            public void GivenIEnterToPage()
            {
                _driver = Helpers.RunPage(_pageObject.PageUrl);
            }

            [Given(@"I have entered ""(.*)"" into the Enter message input")]
            public void GivenIHaveEnteredIntoTheEnterMessageInput(string p0)
            {
                Helpers.WriteText(_pageObject.GetTextBoxMessage(_driver), p0);
            }

            [When(@"I click on Show Message button")]
            public void WhenIClickOnShowMessageButton()
            {
                _pageObject.GetButtonSubmitMessage(_driver).Click();
            }

            [Then(@"the result should be Your Message:""(.*)""")]
            public void ThenTheResultShouldBe(string p0)
            {
                string result = _pageObject.GetDisplayMessage(_driver).Text;
                Helpers.AssertTrue(_driver, p0 == result, "The result is not correct");
            }
        }
    }
}
