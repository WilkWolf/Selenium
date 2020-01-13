
namespace SeleniumApplication.Shared
{
    public static class  Configuration
    {
        public static readonly string  SimpleFormUrl = Helpers.GetValueFromSettings("..Page.Input.BasicForm");
        public static readonly string BaseUrl = Helpers.GetValueFromSettings("Url.Base");
    }
}
