using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandController : ControllerBase
    {
        private IDAL dal;

        public RandController(IDAL dalObject)
        {
            dal = dalObject;
        }

        //[HttpGet]
        //public IEnumerable<Movie> GetRandom(string category = null)
        //{
        //    IEnumerable<Movie> Movies = dal.GetRandomMovie();
        //    return Movies; //serialize the parameter into JSON and return an Ok (20x)
        //    //if (category == null)
        //    //{
        //    //    IEnumerable<Movie> Movies = dal.GetRandomMovie();
        //    //    return Movies; //serialize the parameter into JSON and return an Ok (20x)
        //    //}
        //    //else
        //    //{
        //    //    IEnumerable<Movie> Movies = dal.GetRandomMovie(category);
        //    //    return Movies;
        //    //}
        //}

        [HttpGet]
        public Movie GetRandom(string category = null)
        {

            if (category == null)
            {
                Movie M = dal.GetRandomMovie1();
                return M; //serialize the parameter into JSON and return an Ok (20x)
            }
            else
            {
                Movie M = dal.GetRandomMovieByCategory(category);
                return M; //serialize the parameter into JSON and return an Ok (20x)
            }
        }

        
    }
}