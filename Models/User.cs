using System.Data;

namespace MovieTinder_API.Models
{
    [Attributes.SqlTable("Users", "spGetUser", "spInsertUser", "spUpdateUser", "spDeleteUser")]
    public class User : Object
    {
        public User() 
        {
            Username = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
        }

        [Attributes.SqlColumn("Username", SqlDbType.VarChar)]
        public string Username { get; set; }

        [Attributes.SqlColumn("FirstName", SqlDbType.VarChar)]
        public string FirstName { get; set; }

        [Attributes.SqlColumn("LastName", SqlDbType.VarChar)]
        public string LastName { get; set; }
    }
}
