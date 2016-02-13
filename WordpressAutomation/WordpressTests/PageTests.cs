using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;
using WordpressAutomation.Pages;

namespace WordpressTests
{
    [TestClass]
    public class PageTests
    {
        [TestInitialize]
        public void Initialize()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void SamplePage()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("admin")
                .WithPassword("Niko8603")
                .Login();

            ListPostPage.GoTo(PostType.Page);
            ListPostPage.SelectPost("Sample Page");

            Assert.IsTrue(NewPostPage.IsInEditMode(), "Wasn't in edit mode.");
            Assert.AreEqual("Sample Page", NewPostPage.Title, "Title did not match.");
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Instance.Close();
        }
    }
}
