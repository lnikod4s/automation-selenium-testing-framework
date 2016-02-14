using System;
using OpenQA.Selenium;

namespace WordpressAutomation.Pages
{
    public class ListPostPage
    {
        public static int PreviousPostCount { get; set; }
        public static object CurrentPostCount { get; set; }

        public static void GoTo(PostType postType)
        {
            switch (postType)
            {
                case PostType.Page:
                    LeftNavigation.Pages.AllPages.Select();
                    break;

                default:
                    break;
            }
        }

        public static void StoreCount()
        {
            throw new NotImplementedException();
        }

        public static void SelectPost(string title)
        {
            var postLink = Driver.Instance.FindElement(By.LinkText("Sample Page"));
            postLink.Click();
        }

        public static bool DoesPostExistWithTitle(string v)
        {
            throw new NotImplementedException();
        }

        public static void TrashPost(string v)
        {
            throw new NotImplementedException();
        }
    }

    public enum PostType
    {
        Page,
        Posts
    }
}