using MoviesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Services
{
    public interface IDAL
    {

        IEnumerable<Movie> GetMoviesAll();
        IEnumerable<Movie> GetMoviesByCategory(string category);
        
        Movie GetRandomMovie1();
        Movie GetRandomMovieByCategory(string Category);

    }
}
