using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject
{

    public static class BasicForm
    {
        public static readonly string PageUrl = Helpers.GetValueFromSettings("..Page.Input.BasicForm");
        
        public const string ButtonSubmitMessage = "//*[@id='get-input']/button";
        public const string ButtonSubmitSum = "//*[@id='gettotal']/button";
        public const string TextBoxMessage = "user-message";
        public const string TextBoxSum1 = "sum1";
        public const string TextBoxSum2 = "sum2";
        public const string DisplayMessage = "display";
        public const string DisplaySum = "displayvalue";
    }
}
