using Application.DataAccess;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Application

{
    public static class ConnectionConfig
    {
        public static IDataConnection Connection { get; private set; }

        public static string GetConnectionString(string name)
        {
            IConfiguration config;
            //TODO add appsettings.development.json
            if (Debugger.IsAttached)
            {
                config = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
            }
            else
            {

                config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            }


            string connectionString = config.GetConnectionString(name);

            return connectionString;
        }

        public static void InitializeConnection(DatabaseType db)
        {
            if (db == DatabaseType.Sql)
            {
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
        }

        public static string CnnString(string name)
        {
            string connectionString = GetConnectionString(name);

            return connectionString;

        }
    }
}
