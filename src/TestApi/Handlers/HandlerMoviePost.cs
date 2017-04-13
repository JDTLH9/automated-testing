using Domain;
using TestApi.Clients.Database;

namespace TestApi.Handlers
{
    public interface IHandlerMoviePost
    {
        void Post(Movie movie);
    }

    public class HandlerMoviePost : IHandlerMoviePost
    {
        private readonly IDatabaseClient<Movie> _client;

        public HandlerMoviePost(IDatabaseClient<Movie> client)
        {
            _client = client;
        }

        public void Post(Movie movie)
        {
            _client.InsertItem(movie);
        }
    }
}