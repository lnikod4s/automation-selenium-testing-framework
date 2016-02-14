using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests
{
    public class BaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            Driver.Initialize();
            PostCreator.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs("admin")
                .WithPassword("Niko8603")
                .Login();
        }

        [TestCleanup]
        public void CleanUp()
        {
            PostCreator.CleanUp();
            Driver.Close();
        }
    }
}