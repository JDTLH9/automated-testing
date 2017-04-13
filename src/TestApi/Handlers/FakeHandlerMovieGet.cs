using System;
using System.Collections.Generic;

namespace TestApi.Handlers
{
    public class FakeHandlerMovieGet : IHandlerMovieGet
    {
        public IEnumerable<Domain.Movie> Get()
        {
            throw new NotImplementedException();
        }

        public Domain.Movie Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
