using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IDAL dal;

        public MovieController(IDAL dalObject)
        {
            dal = dalObject;
        }

        [HttpGet]
        public IEnumerable<Movie> Get(string category = null)
        {

            if (category == null)
            {
                IEnumerable<Movie> Movies = dal.GetMoviesAll();
                return Movies; //serialize the parameter into JSON and return an Ok (20x)
            }
            else
            {
                IEnumerable<Movie> Movies = dal.GetMoviesByCategory(category);
                return Movies;
            }
        }

        


    }
}