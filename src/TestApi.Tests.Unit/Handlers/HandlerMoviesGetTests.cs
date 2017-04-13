using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using TestApi.Clients.Database;
using TestApi.Handlers;

namespace TestApi.Tests.Unit.Handlers
{
    [TestFixture]
    public class HandlerMoviesGetTests
    {
        private const int NumberOfMovies = 3;
        private IEnumerable<Movie> _testMovies;
        private IEnumerable<Movie> _returnMovies;
        private Movie _returnMovie;
        private Guid _firstMovieId;

        [SetUp]
        public void GivenAHandlerMoviesGetObject_WhenTheGetEndpointsAreCalled()
        {
            var fixture = new Fixture();
            _testMovies = fixture.CreateMany<Movie>(NumberOfMovies);

            var mockCollection = new Mock<IDatabaseClient<Movie>>();
            mockCollection.Setup(m => m.GetItems()).Returns(() => _testMovies);

            var handler = new HandlerMovieGet(mockCollection.Object);

            _firstMovieId = _testMovies.First().Id;

            _returnMovies = handler.Get();
            _returnMovie = handler.Get().First(m => m.Id == _firstMovieId);
        }

        [Test]
        public void ThenTheCorrectCollectionIsReturned()
        {
            Assert.That(_returnMovie.Id, Is.EqualTo(_firstMovieId));
        }

        [Test]
        public void ThenTheCorrectMovieIsReturned()
        {
            Assert.That(_returnMovies.Count(), Is.EqualTo(NumberOfMovies));
        }
    }
}