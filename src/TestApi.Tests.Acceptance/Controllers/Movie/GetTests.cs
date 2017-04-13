using Domain.Constants;
using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace TestApi.Tests.Acceptance.Controllers.Movie
{
    [TestFixture]
    public class GetTests : TestFixtureBase
    {
        private HttpResponseMessage _response;
        private IEnumerable<Domain.Movie> _testMovies;
        private IEnumerable<Domain.Movie> _returnedMovies;
        private const int NumberOfMovies = 4;

        [OneTimeSetUp]
        public void GivenAMovieRestApiController_WhenTheGetMethodIsCalledWithTheCorrectUriAndNoQueryString()
        {
            var fixture = new Fixture();
            _testMovies = fixture.CreateMany<Domain.Movie>(NumberOfMovies);

            InsertRecords(DatabaseConstants.Movies, _testMovies);

            _response = CallGetEndpoint().Result;
            var jsonContent = _response.Content.ReadAsStringAsync().Result;
            _returnedMovies = new JavaScriptSerializer().Deserialize<IEnumerable<Domain.Movie>>(jsonContent);
        }

        private async Task<HttpResponseMessage> CallGetEndpoint()
        {
            return await RestClient.GetAsync("http://localhost:5000/api/movie");
        }

        [Test]
        public void ThenAnOkStatusCodeShouldBeReturned()
        {
            Assert.That(_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ThenTheMovieDataShouldBeCorrect()
        {
            _returnedMovies.ShouldBeEquivalentTo(_testMovies);
        }
    }
}