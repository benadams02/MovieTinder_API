using System.Data;

namespace MovieTinder_API.Models
{
    public class Object : IObject
    {
        [Attributes.SqlColumn("ID", SqlDbType.Int,PrimaryKey = true)]
        public virtual int ID { get; }

        [Attributes.SqlColumn("DateCreated", SqlDbType.DateTime)]
        public virtual DateTime DateCreated { get; set; }

        [Attributes.SqlColumn("LastModified", SqlDbType.DateTime)]
        public virtual DateTime LastModified { get; set; }

        public Object()
        {
            this.ID = -1;
            this.DateCreated = DateTime.Now;
            this.LastModified = DateTime.Now;
        }
    }
}
