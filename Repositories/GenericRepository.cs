using Microsoft.AspNetCore.Hosting.Server;
using System.Data.SqlClient;
using System.Reflection;

namespace MovieTinder_API.Repositories
{
    public class GenericRepository<ModelType> : IRepository<ModelType> where ModelType : class
    {
        private Type thisType;
        protected Attributes.SqlTable sqlTableAttr { get; set; }
        protected List<PropertyInfo> editableProperties { get; set; }
        public GenericRepository()
        {
            thisType = typeof(ModelType);
            sqlTableAttr = thisType.GetCustomAttributes(typeof(Attributes.SqlTable), true).FirstOrDefault() as Attributes.SqlTable;
            editableProperties = GetSqlProperties(thisType).Values.ToList();
        }

        public bool Delete(int ID)
        {
            if (sqlTableAttr != null && !string.IsNullOrEmpty(sqlTableAttr.DeleteSP))
            {
                SqlCommand cmd = (SqlCommand)Server.DataSource.StoredProcedure(sqlTableAttr.DeleteSP);
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", ID));
                return Server.DataSource.ExecuteQuery(cmd);
            }
            else
            {
                return false;
            }
        }

        public IQueryable<ModelType> GetAll()
        {
            List<ModelType> objects = new List<ModelType>();
            Type thisType = typeof(ModelType);
            Dictionary<Attributes.SqlColumn, PropertyInfo> SqlColumns = GetSqlProperties(thisType);

            if (sqlTableAttr != null && !string.IsNullOrEmpty(sqlTableAttr.GetSP))
            {
                SqlCommand cmd = (SqlCommand)Server.DataSource.StoredProcedure(sqlTableAttr.GetSP);
                cmd.Parameters.Add(new SqlParameter("@ID", DBNull.Value));
                System.Data.DataTable dataTable = Server.DataSource.Read(cmd);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in dataTable.Rows)
                    {
                        var obj = Activator.CreateInstance(thisType);

                        foreach (KeyValuePair<Attributes.SqlColumn, PropertyInfo> kvp in SqlColumns)
                        {
                            var prop = kvp.Value;
                            var column = kvp.Key;
                            if (row[column.FieldName] != DBNull.Value)
                                prop.SetValue(obj, row[column.FieldName]);

                        }
                        if (obj != null)
                            objects.Add((ModelType)obj);
                    }
                    return (IQueryable<ModelType>)objects;
                }

                return null;
            }
            else
            {
                return null;
            }
        }

        public ModelType GetByID(int ID)
        {
            Dictionary<Attributes.SqlColumn, PropertyInfo> SqlColumns = GetSqlProperties(thisType);

            if (sqlTableAttr != null && !string.IsNullOrEmpty(sqlTableAttr.GetSP))
            {
                SqlCommand cmd = (SqlCommand)Server.DataSource.StoredProcedure(sqlTableAttr.GetSP);
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", ID));
                System.Data.DataTable data = Server.DataSource.Read(cmd);

                if (data != null && data.Rows.Count > 0)
                {
                    var obj = Activator.CreateInstance(thisType);
                    var row = data.Rows[0];

                    foreach (KeyValuePair<Attributes.SqlColumn, PropertyInfo> kvp in SqlColumns)
                    {
                        var prop = kvp.Value;
                        var column = kvp.Key;
                        if (row[column.FieldName] != DBNull.Value)
                            prop.SetValue(obj, row[column.FieldName]);

                    }
                    return (ModelType)obj;
                }

                return default(ModelType);
            }
            else
            {
                return default(ModelType);
            }
        }

        public bool Save(ModelType ObjIn)
        {
            throw new NotImplementedException();
        }

        public bool Update(ModelType ObjIn)
        {
            throw new NotImplementedException();
        }

        protected static Dictionary<Attributes.SqlColumn, PropertyInfo> GetSqlProperties(Type type)
        {
            Dictionary<Attributes.SqlColumn, PropertyInfo> SqlColumns = new Dictionary<Attributes.SqlColumn, PropertyInfo>();
            var props = type.GetProperties();

            foreach (var prop in props)
            {
                var attr = (prop.GetCustomAttribute(typeof(Attributes.SqlColumn), true) as Attributes.SqlColumn);
                if (attr != null) SqlColumns.Add(attr, prop);

            }
            return SqlColumns;
        }
    }
}
