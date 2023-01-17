using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTinder_API.Models;
using MovieTinder_API.Services;

namespace MovieTinder_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMoviesController : ControllerBase
    {
        UserMoviesService _userMoviesService;
        MovieService _movieService;

        public UserMoviesController(UserMoviesService userMoviesService, MovieService movieService)
        {
            _userMoviesService = userMoviesService;
            _movieService = movieService;
        }

        [HttpPost]
        public IActionResult LikeMovie(int movieId, UserMovies.UserMovieRatings rating)
        {
            Models.Movie movie = _movieService.GetByID(movieId);

            if (movie == null)
            {
                return NotFound(new ErrorModel() { Code = "404", Message = "Movie not found. Invalid movie ID" });
            }

            if (_movieService.RateMovie(movie, new Models.User(), rating))
            {

            }
            else
            {

            }
        }
    }
}
