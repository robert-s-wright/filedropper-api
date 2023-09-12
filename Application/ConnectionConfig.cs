using Application.DataAccess;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Application

{
    public static class ConnectionConfig
    {
        public static IDataConnection Connection { get; private set; }
        public static string dbName { get; private set; }

        public static void InitializeConnection(DatabaseType db, string name)
        {
            if (db == DatabaseType.Sql)
            {
                SqlConnector sql = new SqlConnector();
                Connection = sql;
                dbName = name;
            }

        }
        public static string CnnString()
        {
            IConfiguration config;

            if (Debugger.IsAttached)
            {
                config = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
            }
            else
            {

                config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            }

            return config.GetConnectionString(dbName);

        }
    }
}
