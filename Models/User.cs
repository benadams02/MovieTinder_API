namespace MovieTinder_API.Models
{
    public class User : Object
    {
        public User() 
        {
            Username = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
