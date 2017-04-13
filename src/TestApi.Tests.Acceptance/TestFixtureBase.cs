using System.Collections.Generic;
using System.Net.Http;
using TestApi.Tests.Acceptance.Service;

namespace TestApi.Tests.Acceptance
{
    public class TestFixtureBase
    {
        public void InsertRecord<T>(string collectionName, T record)
        {
            var collection = ServiceProvider.Db.GetCollection<T>(collectionName);
            collection.InsertOne(record);
        }

        public void InsertRecords<T>(string collectionName, IEnumerable<T> records)
        {
            var collection = ServiceProvider.Db.GetCollection<T>(collectionName);
            collection.InsertMany(records);
        }

        public HttpClient RestClient => ServiceProvider.RestClient;
    }
}