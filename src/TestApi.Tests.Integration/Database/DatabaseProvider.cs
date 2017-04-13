using MongoDB.Driver;

namespace TestApi.Tests.Integration.Database
{
    public static class DatabaseProvider
    {
        private static MongoClient _client;
        private const string DatabaseName = "test-integration-database";
        public static IMongoDatabase Db { get; private set; }

        public static void CreateDatabase()
        {
            _client = new MongoClient();
            Db = _client.GetDatabase(DatabaseName);
        }

        public static void DropDatabase()
        {
            _client.DropDatabase(DatabaseName);
        }
    }
}
