using Domain;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;
using Ploeh.AutoFixture;
using TestApi.Tests.Integration.Database;

namespace TestApi.Tests.Integration.Tests
{
    [TestFixture]
    public abstract class TestBase<T> where T : IDomainEntity
    {
        private IMongoCollection<T> _collection;
        private T _data;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            _data = fixture.Create<T>();
            _collection = DatabaseProvider.Db.GetCollection<T>(typeof(T).Name);
            _collection.InsertOne(_data);
        }

        [TearDown]
        public void TearDown()
        {
            _collection.DeleteOne(t => t.Id == _data.Id);
        }

        [Test]
        public void PickOne()
        {
            var entity = _collection.Find(e => e.Id == _data.Id).First();
            entity.ShouldBeEquivalentTo(_data);
        }
    }
}
