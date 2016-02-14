using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WordpressAutomation
{
    public class ListPostPage
    {
        private static int lastCount;

        public static int PreviousPostCount
        {
            get
            {
                return lastCount;
            }
        }

        public static object CurrentPostCount
        {
            get
            {
                return GetPostCount();
            }
        }

        public static bool IsAt
        {
            get
            {
                var h1s = Driver.Instance.FindElements(By.TagName("h1"));
                if (h1s.Count > 0)
                {
                    return h1s[0].Text == "Posts";
                }

                return false;
            }
        }

        public static void GoTo(PostType postType)
        {
            switch (postType)
            {
                case PostType.Pages:
                    LeftNavigation.Pages.AllPages.Select();
                    break;

                case PostType.Posts:
                    LeftNavigation.Posts.AllPosts.Select();
                    break;

                default:
                    break;
            }
        }

        public static void StoreCount()
        {
            if (!IsAt)
            {
                GoTo(PostType.Posts);
            }

            lastCount = GetPostCount();
        }

        private static int GetPostCount()
        {
            if (!IsAt)
            {
                GoTo(PostType.Posts);
            }

            var countText = Driver.Instance.FindElement(By.ClassName("displaying-num")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static void SelectPost(string title)
        {
            var postLink = Driver.Instance.FindElement(By.LinkText("Sample Page"));
            postLink.Click();
        }

        public static bool DoesPostExistWithTitle(string title)
        {
            return Driver.Instance.FindElements(By.LinkText(title)).Any();
        }

        public static void TrashPost(string title)
        {
            var rows = Driver.Instance.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                ReadOnlyCollection<IWebElement> links = null;
                Driver.NoWait(() => links = row.FindElements(By.LinkText(title)));
                if (links.Count > 0)
                {
                    Actions action = new Actions(Driver.Instance);
                    action.MoveToElement(links[0]);
                    action.Perform();
                    row.FindElement(By.ClassName("submitdelete")).Click();
                    return;
                }
            }
        }

        public static void SearchForPost(string title)
        {
            if (!IsAt)
            {
                GoTo(PostType.Posts);
            }

            Driver.Instance.FindElement(By.Id("post-search-input")).SendKeys(title);
            Driver.Instance.FindElement(By.Id("search-submit")).Click();
        }
    }

    public enum PostType
    {
        Pages,
        Posts
    }
}