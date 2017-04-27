using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MongoDB.Driver;

namespace TestApi.Tests.Acceptance.Service
{
    public static class ServiceProvider
    {
        private static TestServer _server;
        private static MongoClient _client;
        private const string DatabaseName = "test-acceptance-database";
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

        public static void StartApiService()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            RestClient = _server.CreateClient();
        }

        public static void DisposeApiService()
        {
            _server.Dispose();
        }
    }
}