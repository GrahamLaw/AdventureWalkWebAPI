using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWalk.Data
{
    public static class ConfigurationExtensions
    {

        public static string GetAppConnectionString(this IConfiguration configuration)
        {
            var connectionName = "QuizD";
            var connectionString = configuration.GetConnectionString(connectionName);

            if (connectionString == null)
            {
                throw new ApplicationException($"ConnectionString '{connectionName}' does not exist");
                
            }

            return connectionString;
        }

    }
}
