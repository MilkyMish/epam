using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace User_And_Awards_DAL
{
   public static class DatabaseConfig
    {
        public static string GetConnectionString()
        {
            var databaseName = ConfigurationManager.ConnectionStrings["MyConnetionString"];
            return databaseName.ConnectionString;
        }
    }
}
