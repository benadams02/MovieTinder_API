using System.Security.Principal;

namespace MovieTinder_API
{
    public static class Server
    {
        private static MovieTinder_API.Settings _settings = null;
        public static MovieTinder_API.Settings Settings 
        {
            get
            {
                if (_settings != null)
                {
                    return _settings;
                }
                else
                {
                    return MovieTinder_API.Settings.Load();
                }
            }
            set { _settings = value; }
        }
        public static MovieTinder_API.Classes.DataAccess.IDatabase DataSource;
        public static IHttpContextAccessor HttpContext;

        //This method loads the 'server' and is called in Program.cs, it loads in data from the appsettings.json and creates the datasource to connect to the DB
        public static void Load()
        {
            Settings = MovieTinder_API.Settings.Load();
            DataSource = new MovieTinder_API.Classes.DataAccess.MSSQL(Settings.CreateConnectionFromSettings());
            Console.WriteLine("Server Loaded");
        }
        public static void Load(ref IHttpContextAccessor httpContext)
        {
            Settings = MovieTinder_API.Settings.Load();
            DataSource = new MovieTinder_API.Classes.DataAccess.MSSQL(Settings.CreateConnectionFromSettings());
            if(httpContext != null) HttpContext = httpContext;
        }
    }
}
