using Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestApi.Clients.Database
{
    public interface IDatabaseClient<T>
    {
        IEnumerable<T> GetItems();
        T GetItem(Guid id);
        void InsertItem(T item);
        void UpdateItem(FilterDefinition<T> filter, UpdateDefinition<T> update);
        void DeleteItem(Expression<Func<T, bool>> expression);
    }

    public class DatabaseClient<T> : IDatabaseClient<T> where T : IDomainEntity
    {
        private readonly IMongoCollection<T> _collection;

        public DatabaseClient(IMongoCollection<T> collection)
        {
            _collection = collection;
        }

        public IEnumerable<T> GetItems()
        {
            return _collection.AsQueryable();
        }

        public T GetItem(Guid id)
        {
            return _collection.Find(e => e.Id == id).First();
        }

        public void InsertItem(T item)
        {
            _collection.InsertOne(item);
        }

        public void UpdateItem(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            _collection.UpdateOne(filter, update);
        }

        public void DeleteItem(Expression<Func<T, bool>> expression)
        {
            _collection.DeleteOne(expression);
        }
    }
}