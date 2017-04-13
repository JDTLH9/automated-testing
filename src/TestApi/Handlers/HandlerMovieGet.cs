using Domain;
using System;
using System.Collections.Generic;
using TestApi.Clients.Database;

namespace TestApi.Handlers
{
    public interface IHandlerMovieGet
    {
        IEnumerable<Movie> Get();
        Movie Get(Guid id);
    }

    public class HandlerMovieGet : IHandlerMovieGet
    {
        private readonly IDatabaseClient<Movie> _client;

        public HandlerMovieGet(IDatabaseClient<Movie> client)
        {
            _client = client;
        }

        public IEnumerable<Movie> Get()
        {
            return _client.GetItems();
        }

        public Movie Get(Guid id)
        {
            return _client.GetItem(id);
        }
    }
}