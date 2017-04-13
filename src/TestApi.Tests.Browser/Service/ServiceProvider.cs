using System.Net.Http;
using MongoDB.Driver;

namespace TestApi.Tests.Browser.Service
{
    public static class ServiceProvider
    {
        private static MongoClient _client;
        private const string DatabaseName = "test-browser-database";
        public static HttpClient RestClient { get; set; }
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
