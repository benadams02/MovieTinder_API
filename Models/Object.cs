namespace MovieTinder_API.Models
{
    public class Object : IObject
    {
        public int ID { get; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }

        public Object()
        {
            this.ID = -1;
            this.DateCreated = DateTime.Now;
            this.LastModified = DateTime.Now;
        }
    }
}
