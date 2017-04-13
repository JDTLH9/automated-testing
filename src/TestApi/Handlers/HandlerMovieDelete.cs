using Domain;
using System;
using TestApi.Clients.Database;

namespace TestApi.Handlers
{
    public interface IHandlerMovieDelete
    {
        void Delete(Guid id);
    }

    public class HandlerMovieDelete : IHandlerMovieDelete
    {
        private readonly IDatabaseClient<Movie> _client;

        public HandlerMovieDelete(IDatabaseClient<Movie> client)
        {
            _client = client;
        }

        public void Delete(Guid  id)
        {
            _client.DeleteItem(m => m.Id == id);
        }
    }
}