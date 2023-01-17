namespace MovieTinder_API.Models
{
    public class UserMovies : Object
    {
        public UserMovies() 
        {
        }
        public UserMovies(Movie movie, User user)
        {
            this.UserID = user.ID;
            this.MovieID = movie.ID;
        }
        public UserMovies(Movie movie, User user, UserMovieRatings rating)
        {
            this.UserID = user.ID;
            this.MovieID = movie.ID;
            this.Rating = rating;
        }

        public int UserID { get; set; }

        public int MovieID { get; set; }

        public UserMovieRatings Rating { get; set; }

        public enum UserMovieRatings 
        {
            SuperLike,
            Like,
            Neutral,
            Dislike
        }
    }
}
