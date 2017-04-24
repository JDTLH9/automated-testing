using Domain;
using Domain.Constants;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore;
using TestApi.Clients.Database;
using TestApi.Handlers;

namespace TestApi.Registry
{
    public class TestApiRegistry
    {
        public void Register(Container container, IConfigurationRoot configuration)
        {
            container.Options.AllowOverridingRegistrations = true;
            container.Options.DefaultScopedLifestyle = new AspNetRequestLifestyle();

            var databaseName = configuration.GetSection("Database").Get<DatabaseSettings>().Name;
            
            CustomRegistrations(container, databaseName);

            container.Verify();
        }

        private static void CustomRegistrations(Container container, string databaseName)
        {
            var collection = GetMoviesCollection(databaseName);
            container.Register<IDatabaseClient<Movie>>(() => new DatabaseClient<Movie>(collection), Lifestyle.Singleton);
            container.Register<IHandlerMovieDelete, HandlerMovieDelete>(Lifestyle.Singleton);
            container.Register<IHandlerMovieGet, HandlerMovieGet>(Lifestyle.Singleton);
            container.Register<IHandlerMoviePost, HandlerMoviePost>(Lifestyle.Singleton);
            container.Register<IHandlerMoviePut, HandlerMoviePut>(Lifestyle.Singleton);
        }

        private static IMongoCollection<Movie> GetMoviesCollection(string databaseName)
        {
            var client = new MongoClient();
            var database = client.GetDatabase(databaseName);
            return database.GetCollection<Movie>(DatabaseConstants.Movies);
        }
    }
}