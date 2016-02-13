using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WordpressAutomation
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("http://localhost:41186/wp-login.php");
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "user_login");
        }

        public static LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username);
        }
    }

    public class LoginCommand
    {
        private readonly string username;
        private string password;

        public LoginCommand(string username)
        {
            this.username = username;
        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public void Login()
        {
            var username = Driver.Instance.FindElement(By.Id("user_login"));
            username.SendKeys(this.username);

            var password = Driver.Instance.FindElement(By.Id("user_pass"));
            password.SendKeys(this.password);

            var submit = Driver.Instance.FindElement(By.Id("wp-submit"));
            submit.Click();
        }
    }
}