using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab_15._2_Creating_A_Rest_API.Controllers
{
    [Route("Movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet("MovieList")]
        public List<Movie> MovieList()
        {
            List<Movie> movie = new List<Movie>();
            movie = Movie.ReadAll();
            return movie;
        }

        [HttpGet("Category/{catid}")]
        public List<Movie> CategorySearch(string catid)
        {
            List<Movie> movie = new List<Movie>();
            movie = Movie.CategorySearch(catid);
            return movie;
        } 

        [HttpGet("Random")]
        public Movie RandomMovie()
        {
            Movie movie = new Movie();
            movie = Movie.RandomMovie();
            return movie;
        }

        [HttpGet("{cat}/Random")]
        public Movie RandomCategory(string category)
        {
            Movie movie = new Movie();
            movie = Movie.RandomCategory(category);
            return movie;
        }
            
    }

   
}
