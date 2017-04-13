using NUnit.Framework;
using TestApi.Tests.Browser.Service;

namespace TestApi.Tests.Browser
{
    [SetUpFixture]
    public class TestSetup
    {
        [OneTimeSetUp]
        public void Setup()
        {
            ServiceProvider.CreateDatabase();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ServiceProvider.DropDatabase();
        }
    }
}
