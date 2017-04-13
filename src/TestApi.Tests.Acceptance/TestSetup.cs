using NUnit.Framework;
using TestApi.Tests.Acceptance.Service;

namespace TestApi.Tests.Acceptance
{
    [SetUpFixture]
    public class TestSetup
    {
        [OneTimeSetUp]
        public void Setup()
        {
            ServiceProvider.CreateDatabase();
            ServiceProvider.StartApiService();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ServiceProvider.DisposeApiService();
            ServiceProvider.DropDatabase();
        }
    }
}
