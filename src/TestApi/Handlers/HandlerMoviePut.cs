using System;
using Domain;
using MongoDB.Driver;
using TestApi.Clients.Database;

namespace TestApi.Handlers
{
    public interface IHandlerMoviePut
    {
        void Put(Guid id, Movie movie);
    }

    public class HandlerMoviePut : IHandlerMoviePut
    {
        private readonly IDatabaseClient<Movie> _client;

        public HandlerMoviePut(IDatabaseClient<Movie> client)
        {
            _client = client;
        }

        public void Put(Guid id, Movie movie)
        {
            var filter = Builders<Movie>.Filter.Eq("Id", id);
            var update = Builders<Movie>.Update
                .Set("Title", movie.Title)
                .Set("Year", movie.Year)
                .Set("Description", movie.Description)
                .Set("Runtime", movie.Runtime)
                .Set("Rating", movie.Rating);

            _client.UpdateItem(filter, update);
        }
    }
}