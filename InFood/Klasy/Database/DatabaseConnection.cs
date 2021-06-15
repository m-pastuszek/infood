using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using InFood.Klasy.Exceptions;

namespace InFood.Klasy.Database
{
    class DatabaseConnection
    {
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "infood.database.windows.net";
            builder.UserID = "infood";
            builder.Password = "Admin#2021";
            builder.InitialCatalog = "infood";
            string connectionString = builder.ConnectionString;

            return connectionString;
        }
    }
}
