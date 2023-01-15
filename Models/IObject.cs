namespace MovieTinder_API.Models
{
    public interface IObject
    {
        public int ID { get; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
