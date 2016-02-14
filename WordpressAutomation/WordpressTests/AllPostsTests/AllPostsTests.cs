using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;
using WordpressAutomation.Pages;

namespace WordpressTests.AllPostsTests
{
    [TestClass]
    public class AllPostsTests : BaseTest
    {
        [TestMethod]
        public void AddedPostsShowUp()
        {
            //Go to All Posts, get posts count and store it
            ListPostPage.GoTo(PostType.Posts);
            ListPostPage.StoreCount();

            //Add new post
            NewPostPage.GoTo();
            NewPostPage.CreatePost("Added posts show up, title")
                .WithBody("Added post shows up, body")
                .Publish();

            //Go back to All Posts, get new posts count
            ListPostPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostPage.PreviousPostCount + 1, ListPostPage.CurrentPostCount, "Posts count did not increase.");

            //Check for just added post
            Assert.IsTrue(ListPostPage.DoesPostExistWithTitle("Added posts show up, title"));

            //Trash post(clean up)
            ListPostPage.TrashPost("Added posts show up, title");
            Assert.AreEqual(ListPostPage.PreviousPostCount, ListPostPage.CurrentPostCount, "Couldn't trash post.");
        }
    }
}