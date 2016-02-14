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
            LoginPage.GoTo();
            LoginPage.LoginAs("admin")
                .WithPassword("Niko8603")
                .Login();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}