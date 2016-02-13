using OpenQA.Selenium;

namespace WordpressAutomation
{
    public class DashboardPage
    {
        public static bool IsAt
        {
            get
            {
                var h1s = Driver.Instance.FindElements(By.TagName("h1"));
                if (h1s.Count > 0)
                {
                    return h1s[0].Text == "Dashboard";
                }

                return false;
            }
        }
    }
}