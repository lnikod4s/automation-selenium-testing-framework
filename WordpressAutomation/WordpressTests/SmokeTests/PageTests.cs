using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;
using WordpressAutomation.Pages;

namespace WordpressTests
{
    [TestClass]
    public class PageTests : BaseTest
    {
        [TestMethod]
        public void SamplePage()
        {
            ListPostPage.GoTo(PostType.Page);
            ListPostPage.SelectPost("Sample Page");

            Assert.IsTrue(NewPostPage.IsInEditMode(), "Wasn't in edit mode.");
            Assert.AreEqual("Sample Page", NewPostPage.Title, "Title did not match.");
        }
    }
}