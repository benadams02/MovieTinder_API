using MovieTinder_API.Models;
using MovieTinder_API.Repositories;

namespace MovieTinder_API.Services
{
    public class MovieService : IService<Models.Movie>
    {
        private Repositories.MovieRepository _movieRepository;
        private Services.UserMoviesService _userMoviesService;

        public MovieService(MovieRepository movieRepository, UserMoviesService userMoviesService) 
        {
            _movieRepository = movieRepository;
            _userMoviesService = userMoviesService;
        }

        public Models.Movie GetByID(int id)
        {
            return _movieRepository.GetByID(id);
        }

        public List<Models.Movie> GetAll()
        {
            return _movieRepository.GetAll().ToList();
        }

        public bool LikeMovie(Movie movie, User user)
        {
            Models.UserMovies userMovie = _userMoviesService.Create(movie, user);

            if (_userMoviesService.Save(userMovie))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LikeMovie(Movie movie, User user, UserMovies.UserMovieRatings movieRating)
        {
            Models.UserMovies userMovie = _userMoviesService.Create(movie, user, movieRating);

            if (_userMoviesService.Save(userMovie))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Movie modelType)
        {
            throw new NotImplementedException();
        }

        public bool Save(Movie modelType)
        {
            throw new NotImplementedException();
        }

        public Movie Create()
        {
            throw new NotImplementedException();
        }
    }
}
