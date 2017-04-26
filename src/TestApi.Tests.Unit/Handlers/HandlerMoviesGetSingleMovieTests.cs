using System.Collections.Generic;
using System.Linq;
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
    public class HandlerMoviesGetSingleMovieTests
    {
        private const int NumberOfMovies = 3;
        private IEnumerable<Movie> _testMovies;
        private Movie _returnMovie;
        private Mock<IDatabaseClient<Movie>> _mockClient;
        private Movie _getMovie;

        [SetUp]
        public void GivenAHandlerMoviesGetObject_WhenTheGetEndpointIsCalledWithTheIdOfASingleMovie()
        {
            var fixture = new Fixture();
            _testMovies = fixture.CreateMany<Movie>(NumberOfMovies);
            _getMovie = _testMovies.OrderBy(m => m.Id).First();

            _mockClient = new Mock<IDatabaseClient<Movie>>();
            _mockClient.Setup(m => m.GetItem(_getMovie.Id)).Returns(() => _getMovie);

            var handler = new HandlerMovieGet(_mockClient.Object);
            _returnMovie = handler.Get(_getMovie.Id);
        }

        [Test]
        public void ThenTheCorrectMovieIsReturned()
        {
            _returnMovie.ShouldBeEquivalentTo(_getMovie);
        }

        [Test]
        public void ThenTheMethodToGetASingleMovieIsCalledOnTheClient()
        {
            _mockClient.Verify(m => m.GetItem(_getMovie.Id), Times.Exactly(1));
        }
    }
}