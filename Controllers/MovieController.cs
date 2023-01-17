using Microsoft.AspNetCore.Mvc;
using MovieTinder_API.Repositories;
using MovieTinder_API.Services;
using System.Text.Json;

namespace MovieTinder_API.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        Services.MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpGet, Route("/api/[controller]/{id}")]
        public IActionResult GetByID(int id)
        {
            Models.Movie movie = _movieService.GetByID(id);

            string movieAsJson = JsonSerializer.Serialize(movie);

            return Ok(movieAsJson);
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            List<Models.Movie> movies = _movieService.GetAll();

            string moviesAsJson = JsonSerializer.Serialize(movies);

            return Ok(moviesAsJson);
        }

        //[HttpGet]
        //public IActionResult GetByName(string name)
        //{
        //    Models.Movie movie = _movieRepo.GetByName(name);

        //    string movieAsJson = JsonSerializer.Serialize(movie);

        //    return Ok(movieAsJson);
        //}
    }
}
