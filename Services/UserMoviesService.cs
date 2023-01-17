using MovieTinder_API.Models;
using MovieTinder_API.Repositories;

namespace MovieTinder_API.Services
{
    public class UserMoviesService : IService<Models.UserMovies>
    {
        private Repositories.UserMoviesRepository _userMoviesRepository;

        public UserMoviesService(UserMoviesRepository userMoviesRepository)
        {
            _userMoviesRepository = userMoviesRepository;
        }

        public UserMovies Create()
        {
            throw new NotImplementedException();
        }

        public UserMovies Create(Movie movie, User user)
        {
            Models.UserMovies userMovie = new UserMovies(movie, user);

            return userMovie;
        }
        public UserMovies Create(Movie movie, User user, UserMovies.UserMovieRatings rating)
        {
            Models.UserMovies userMovie = new UserMovies(movie, user, rating);

            return userMovie;
        }

        public bool Delete(UserMovies modelType)
        {
            throw new NotImplementedException();
        }

        public UserMovies GetByID(int id)
        {
            return _userMoviesRepository.GetByID(id);
        }

        public bool Save(UserMovies modelType)
        {
            throw new NotImplementedException();
        }
    }
}
