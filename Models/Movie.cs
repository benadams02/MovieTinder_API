namespace MovieTinder_API.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public int Rating { get; set; }
    }
}
