using OpenQA.Selenium.Chrome;
using SeleniumApplication.PageObject.Input;
using SeleniumApplication.Shared;
using TechTalk.SpecFlow;

namespace SpecFlowApplication.Steps
{
    [Binding]
    public class MultipleCheckboxSteps
    {
        readonly PageObjectBasicCheckbox _pageObject = new PageObjectBasicCheckbox();
        private ChromeDriver _driver;

        [Given(@"I go to basic-first-form-demo\.html page")]
        public void GivenIGoToBasic_First_Form_Demo_HtmlPage()
        {
            _driver = Helpers.RunPage(_pageObject.PageUrl);
        }
        
        [When(@"I click all checkbox  button in multiple checkbox form")]
        public void WhenIClickAllCheckboxButtonInMultipleCheckboxForm()
        {
            _pageObject.GetCheckBox1(_driver).Click();
            _pageObject.GetCheckBox2(_driver).Click();
            _pageObject.GetCheckBox3(_driver).Click();
            _pageObject.GetCheckBox4(_driver).Click();
        }
        
        [Then(@"the button should change text from ""(.*)"" to ""(.*)""")]
        public void ThenTheButtonShouldChangeTextFromTo(string p0, string p1)
        {
            string result = Helpers.GetValue(_pageObject.GetButtonCheck(_driver));
            Helpers.AssertFalse(_driver,result == p0,"Message wan not change");
            Helpers.AssertTrue(_driver, result == p1, "Result is not correct");
        }
    }
}
