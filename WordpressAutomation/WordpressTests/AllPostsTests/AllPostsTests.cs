using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests.AllPostsTests
{
    [TestClass]
    public class AllPostsTests : BaseTest
    {
        [TestMethod]
        public void AddedPostShowUp()
        {
            ListPostPage.StoreCount();
            PostCreator.CreatePost();
            Assert.AreEqual(ListPostPage.PreviousPostCount + 1, ListPostPage.CurrentPostCount, "Posts count did not increase.");
            Assert.IsTrue(ListPostPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));
        }

        [TestMethod]
        public void SearchPosts()
        {
            PostCreator.CreatePost();
            ListPostPage.SearchForPost(PostCreator.PreviousTitle);
            Assert.IsTrue(ListPostPage.DoesPostExistWithTitle(PostCreator.PreviousTitle), "Searched post does not exist.");
        }
    }
}