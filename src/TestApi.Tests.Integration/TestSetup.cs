using NUnit.Framework;
using TestApi.Tests.Integration.Database;
using TestApi.Tests.Integration.Tests;

namespace TestApi.Tests.Integration
{
    [SetUpFixture]
    public class TestSetup
    {
        [OneTimeSetUp]
        public void Setup()
        {
            DatabaseProvider.CreateDatabase();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            DatabaseProvider.DropDatabase();
        }
    }
}
