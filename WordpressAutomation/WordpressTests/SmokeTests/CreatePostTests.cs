using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests
{
    [TestClass]
    public class CreatePostTests : BaseTest
    {
        [TestMethod]
        public void CreateBasicPost()
        {
            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the test post title")
                .WithBody("Hi, this is the post body.")
                .Publish();
            NewPostPage.GoToNewPost();

            Assert.AreEqual(PostPage.Title, "This is the test post title", "Title did not match new post.");
        }
    }
}