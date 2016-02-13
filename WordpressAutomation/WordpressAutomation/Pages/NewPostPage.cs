using System.Threading;
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
            var menuPosts = Driver.Instance.FindElements(By.ClassName("wp-menu-name"))[1];
            menuPosts.Click();

            var addNew = Driver.Instance.FindElement(By.LinkText("Add New"));
            addNew.Click();
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
            Driver.Instance.FindElement(By.Id("title-prompt-text")).SendKeys(this.title);
            Driver.Instance.SwitchTo().Frame("content_ifr");
            Driver.Instance.SwitchTo().ActiveElement().SendKeys(this.body);
            Driver.Instance.SwitchTo().DefaultContent();

            Thread.Sleep(1000);

            Driver.Instance.FindElement(By.Id("publish")).Click();
        }
    }
}