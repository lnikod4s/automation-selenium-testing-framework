using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests
{
    [TestClass]
    public class CreatePostTests
    {
        [TestInitialize]
        public void Initialize()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void CreateBasicPost()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("admin")
                .WithPassword("Niko8603")
                .Login();

            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the test post title")
                .WithBody("Hi, this is the post body.")
                .Publish();
            NewPostPage.GoToNewPost();

            Assert.AreEqual(PostPage.Title, "This is the test post title", "Title did not match new post.");
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Instance.Close();
        }
    }
}