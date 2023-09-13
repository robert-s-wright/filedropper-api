using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Application
{
    public static class DirectoryConfig
    {


        public static string GetBaseDir()
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

            string dir = config.GetSection("FileDir").Value;

            return dir;
        }
    }
}
