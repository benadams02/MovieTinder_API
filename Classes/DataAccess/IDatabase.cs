using System.Data;

namespace MovieTinder_API.Classes.DataAccess
{
    public interface IDatabase
    {
        public IDbConnection Connection { get; }
        public IDbCommand StoredProcedure(string command);
        public bool OpenConnection(int retryCount = 0);
        public bool CloseConnection(int retryCount = 0);
        public bool ExecuteQuery(IDbCommand command);
        public DataTable Read(IDbCommand command);
        public bool BackupDatabase(string? path = null);
        public string BackupDirectory { get; set; }
    }
}
