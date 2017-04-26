using System.Collections.Generic;
using Domain;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using TestApi.Clients.Database;
using TestApi.Handlers;

namespace TestApi.Tests.Unit.Handlers
{
    [TestFixture]
    public class HandlerMoviesGetAllMoviesTests
    {
        private const int NumberOfMovies = 3;
        private IEnumerable<Movie> _testMovies;
        private IEnumerable<Movie> _returnMovies;
        private Mock<IDatabaseClient<Movie>> _mockClient;

        [SetUp]
        public void GivenAHandlerMoviesGetObject_WhenTheGetEndpointForAllMoviesIsCalled()
        {
            var fixture = new Fixture();
            _testMovies = fixture.CreateMany<Movie>(NumberOfMovies);

            _mockClient = new Mock<IDatabaseClient<Movie>>();
            _mockClient.Setup(m => m.GetItems()).Returns(() => _testMovies);

            var handler = new HandlerMovieGet(_mockClient.Object);
            _returnMovies = handler.Get();
        }

        [Test]
        public void ThenTheCorrectCollectionOfMoviesIsReturned()
        {
            _returnMovies.ShouldBeEquivalentTo(_testMovies);
        }

        [Test]
        public void ThenTheMethodToGetAllMoviesIsCalledOnTheClient()
        {
            _mockClient.Verify(m => m.GetItems(), Times.Exactly(1));
        }
    }
}