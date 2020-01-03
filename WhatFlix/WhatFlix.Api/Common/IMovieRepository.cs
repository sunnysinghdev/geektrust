using System.Collections.Generic;
using WhatFlix.Api.Model;

namespace WhatFlix.Common
{

    public interface IMovieRepositry: IRepository<Movie>
    {
        IEnumerable<Movie> GetByTitle(string text);
    }
}