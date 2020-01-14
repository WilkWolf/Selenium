

using SeleniumApplication.Shared;

namespace SeleniumApplication.PageObject
{
    public static class BasicCheckbox
    {
        public static readonly string PageUrl = Helpers.GetValueFromSettings("..Page.Input.CheckBox");
        public const string CheckBoxAge = "isAgeSelected";
        public const string MessageSelectedAge = "txtAge";

        public const string CheckBox1 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[1]/label/input";
        public const string CheckBox2 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[2]/label/input";
        public const string CheckBox3 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[3]/label/input";
        public const string CheckBox4 = "//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[4]/label/input";


        public const string ButtonCheck = "check1";

    }
}


