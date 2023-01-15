using MovieTinder_API.Repositories;

namespace MovieTinder_API.Services
{
    public class MovieService
    {
        private Repositories.MovieRepository _movieRepository;

        public MovieService(MovieRepository movieRepository) 
        {
            _movieRepository = movieRepository;
        }


    }
}
