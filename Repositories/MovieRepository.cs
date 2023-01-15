namespace MovieTinder_API.Repositories
{
    public class MovieRepository : GenericRepository<Models.Movie>
    {
        public MovieRepository() 
        { 
            
        }

        public Models.Movie GetByName(string name) 
        {
            return null;
        }
    } 
}
