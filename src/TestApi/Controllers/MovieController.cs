using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestApi.Handlers;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IHandlerMovieGet _handlerMovieGet;
        private readonly IHandlerMoviePost _handlerMoviesPost;
        private readonly IHandlerMoviePut _handlerMoviesPut;
        private readonly IHandlerMovieDelete _handlerMovieDelete;

        public MovieController(IHandlerMovieGet handlerMovieGet, IHandlerMoviePost handlerMoviesPost, IHandlerMoviePut handlerMoviesPut, IHandlerMovieDelete handlerMovieDelete)
        {
            _handlerMovieGet = handlerMovieGet;
            _handlerMoviesPost = handlerMoviesPost;
            _handlerMoviesPut = handlerMoviesPut;
            _handlerMovieDelete = handlerMovieDelete;
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _handlerMovieGet.Get();
        }

        [HttpGet("{id}")]
        public Movie Get(Guid id)
        {
            return _handlerMovieGet.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Movie movie)
        {
            _handlerMoviesPost.Post(movie);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Movie movie)
        {
            _handlerMoviesPut.Put(id, movie);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _handlerMovieDelete.Delete(id);
        }
    }
}
