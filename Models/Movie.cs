using System.Data;

namespace MovieTinder_API.Models
{
    [Attributes.SqlTable("Movies","spGetMovie","spInsertMovie","spUpdateMovie","spDeleteMovie")]
    public class Movie : Object
    {
        [Attributes.SqlColumn("Name",SqlDbType.VarChar)]
        public string Name { get; set; }

        [Attributes.SqlColumn("Description", SqlDbType.VarChar)]
        public string Description { get; set; }

        [Attributes.SqlColumn("Name", SqlDbType.TinyInt)]
        public int Rating { get; set; }
    }
}
