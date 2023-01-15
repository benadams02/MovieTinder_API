using System.Data;
using System.Data.SqlClient;

namespace MovieTinder_API.Classes.DataAccess
{
    public class MSSQL : IDatabase
    {
        public MSSQL(IDbConnection connection) 
        {
            Connection = connection;
        }
        public IDbConnection Connection { get; }
        public string BackupDirectory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool BackupDatabase(string? path = null)
        {
            if (!string.IsNullOrEmpty(path))
            {
                return ExecuteQuery(new SqlCommand("", (SqlConnection)this.Connection));
            }

            if (!string.IsNullOrEmpty(BackupDirectory))
            {
                return ExecuteQuery(new SqlCommand("", (SqlConnection)this.Connection));
            }
            else
            {
                return false;
            }
        }

        public bool CloseConnection(int retryCount = 0)
        {
            if (retryCount <= 3)
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        Connection.Close();
                        if (Connection.State == System.Data.ConnectionState.Closed)
                        {
                            return true;
                        }
                        else
                        {
                            return CloseConnection(retryCount++);
                        }
                    }
                    catch (Exception)
                    {
                        CloseConnection(retryCount++);
                        throw;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ExecuteQuery(IDbCommand command)
        {
            throw new NotImplementedException();
        }

        public bool OpenConnection(int retryCount = 0)
        {
            if (retryCount <= 3)
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                {
                    try
                    {
                        Connection.Open();
                        if (Connection.State == System.Data.ConnectionState.Open)
                        {
                            return true;
                        }
                        else
                        {
                            return OpenConnection(retryCount++);
                        }
                    }
                    catch (Exception)
                    {
                        Connection.Close();
                        OpenConnection(retryCount++);
                        throw;
                    }
                }
                else
                {
                    CloseConnection();
                    return OpenConnection(retryCount++);
                }
            }
            else
            {
                return false;
            }
        }

        public DataTable Read(IDbCommand command)
        {
            throw new NotImplementedException();
        }

        public IDbCommand StoredProcedure(string command)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(command, (System.Data.SqlClient.SqlConnection)this.Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }
    }
}
