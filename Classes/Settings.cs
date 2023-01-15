using System.Data.SqlClient;
using System.Data;
using System.Text.Json;

namespace MovieTinder_API
{
    public class Settings
    {
        public string InstanceName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }

        public static Settings Load()
        {
            //Check if appsettings exists in the directory the app is running from
            if (System.IO.File.Exists("appsettings.json"))
            {
                Settings settings;
                string appsettings = System.IO.File.ReadAllText("appsettings.json");
                //deserialize whole file
                var config = JsonSerializer.Deserialize<Dictionary<string, object>>(appsettings);
                //deserialize Settings json object to a Settings Model then return it
                settings = JsonSerializer.Deserialize<Settings>(JsonSerializer.Serialize(config["Settings"]));

                return settings;
            }
            else
            {
                return null;
            }
        }

        public SqlConnection CreateConnectionFromSettings()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.UserID = Server.Settings.Username;
            builder.Password = Server.Settings.Password;
            builder.DataSource = Server.Settings.InstanceName;
            builder.InitialCatalog = Server.Settings.DatabaseName;
            builder.ConnectTimeout = 60;

            SqlConnection thisConn = new SqlConnection(builder.ConnectionString);

            if (thisConn.State == System.Data.ConnectionState.Closed)
            {
                thisConn.Open();
                if (thisConn.State == ConnectionState.Open)
                {
                    thisConn.Close();
                    return thisConn;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                thisConn.Close();
                return thisConn;
            }
        }
    }
}
