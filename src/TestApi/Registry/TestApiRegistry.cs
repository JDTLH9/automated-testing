using Domain;
using Domain.Constants;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore;
using System.Linq;
using TestApi.Clients.Database;
using TestApi.Controllers;

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

            ScanAssembly(container);

            container.Verify();
        }

        private static void CustomRegistrations(Container container, string databaseName)
        {
            var collection = GetMoviesCollection(databaseName);
            container.Register<IDatabaseClient<Movie>>(() => new DatabaseClient<Movie>(collection), Lifestyle.Singleton);
        }

        private static void ScanAssembly(Container container)
        {
            var assembly = typeof(MovieController).Assembly;

            var registrations =
                assembly.GetExportedTypes()
                    .Where(type => type.Namespace == "TestApi.Handlers")
                    .Where(type => type.GetInterfaces().Any())
                    .Select(type => new { Service = type.GetInterfaces().First(), Implementation = type });

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation, Lifestyle.Scoped);
            }
        }

        private static IMongoCollection<Movie> GetMoviesCollection(string databaseName)
        {
            var client = new MongoClient();
            var database = client.GetDatabase(databaseName);
            return database.GetCollection<Movie>(DatabaseConstants.Movies);
        }
    }
}