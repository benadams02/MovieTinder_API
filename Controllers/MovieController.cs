using Microsoft.AspNetCore.Mvc;
using MovieTinder_API.Repositories;
using System.Text.Json

namespace MovieTinder_API.Controllers
{
    public class MovieController : Controller
    {
        Repositories.MovieRepository _movieRepo;

        public MovieController(MovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }

        public IActionResult GetByID(int id)
        {
            Models.Movie movie = _movieRepo.GetByID(id);

            string movieAsJson = JsonSerializer.Serialize(movie);

            return Ok(movieAsJson);
        }

        public IActionResult GetByName(string name)
        {
            Models.Movie movie = _movieRepo.GetByName(name);

            string movieAsJson = JsonSerializer.Serialize(movie);

            return Ok(movieAsJson);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
