using System.Data;

namespace MovieTinder_API.Models
{
    [Attributes.SqlTable("Movies","spGetMovie","spInsertMovie","spUpdateMovie","spDeleteMovie")]
    public class Movie : Object
    {
        [Attributes.SqlColumn("Title",SqlDbType.VarChar)]
        public string Title { get; set; }

        [Attributes.SqlColumn("Description", SqlDbType.VarChar)]
        public string Description { get; set; }

        [Attributes.SqlColumn("Rating", SqlDbType.Decimal)]
        public decimal Rating { get; set; }
    }
}
