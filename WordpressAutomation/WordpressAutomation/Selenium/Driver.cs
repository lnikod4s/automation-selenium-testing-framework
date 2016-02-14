using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WordpressAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static string BaseUrl
        {
            get { return "http://localhost:41186/"; }
        }

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            Instance.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(20));
            Instance.Manage().Window.Maximize();
        }

        public static void Close()
        {
            Instance.Close();
        }

        internal static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)(timeSpan.TotalSeconds * 1000));
        }
    }
}