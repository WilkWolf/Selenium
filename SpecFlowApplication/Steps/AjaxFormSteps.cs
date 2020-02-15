using System.Threading;
using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.Input;
using SeleniumApplication.Shared;
using TechTalk.SpecFlow;

namespace SpecFlowApplication.Steps
{
    [Binding]
    public class AjaxFormSteps
    {
        readonly PageObjectAjaxFormSubmit _pageObject = new PageObjectAjaxFormSubmit();
        private ChromeDriver _driver;

        [Given(@"I go page to ajax-form-submit-demo\.html page")]
        public void GivenIGoPageToAjax_Form_Submit_Demo_HtmlPage()
        {
            _driver = Helpers.RunPage(_pageObject.PageUrl);
        }
        
        [Given(@"I have entered ""(.*)"" into the Name input")]
        public void GivenIHaveEnteredIntoTheNameInput(string p0)
        {
            Helpers.WriteText(_pageObject.GetNameInput(_driver),p0);
        }
        
        [Given(@"I have entered ""(.*)"" into the Comment input")]
        public void GivenIHaveEnteredIntoTheCommentInput(string p0)
        {
            Helpers.WriteText(_pageObject.GetCommentInput(_driver), p0);
        }
        
        [When(@"I click on Submit button")]
        public void WhenIClickOnSubmitButton()
        {
            _pageObject.GetSubmitButton(_driver).Click();
        }

        [When(@"Wait 1 second")]
        public void WhenWait1Second()
        {
            Thread.Sleep(1000);
        }

        [Then(@"the result should be ""(.*)""")]
        public void ThenTheResultShouldBe(string p0)
        {
            string result = _pageObject.GetDisplayMessage(_driver).Text;
            Helpers.AssertTrue(_driver, p0 == result,"result is not correct");
        }
    }
}
