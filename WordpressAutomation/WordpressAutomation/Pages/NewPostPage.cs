using System;
using OpenQA.Selenium;

namespace WordpressAutomation
{
    public class NewPostPage
    {
        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.Id("title")).GetAttribute("value");
                if (title != null)
                {
                    return title;
                }

                return string.Empty;
            }
        }

        public static void GoTo()
        {
            LeftNavigation.Posts.AddNew.Select();
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GoToNewPost()
        {
            var message = Driver.Instance.FindElement(By.Id("message"));
            var newPostLink = message.FindElements(By.TagName("a"))[0];
            newPostLink.Click();
        }

        public static bool IsInEditMode()
        {
            return Driver.Instance.FindElement(By.TagName("h1")).Text.Contains("Edit Page");
        }
    }

    public class CreatePostCommand
    {
        private readonly string title;
        private string body;

        public CreatePostCommand(string title)
        {
            this.title = title;
        }

        public CreatePostCommand WithBody(string body)
        {
            this.body = body;
            return this;
        }

        public void Publish()
        {
            Driver.Instance.FindElement(By.Id("title")).SendKeys(title);
            Driver.NoWait(() => Driver.Instance.SwitchTo().Frame("content_ifr"));
            Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
            Driver.NoWait(() => Driver.Instance.SwitchTo().DefaultContent());

            Driver.Wait(TimeSpan.FromSeconds(1));

            Driver.Instance.FindElement(By.Id("publish")).Click();
        }
    }
}