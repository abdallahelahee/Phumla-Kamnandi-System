using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Group38_INF2011S_Group_Project_2025.Database
{
    public class DatabaseHelper
    {
        private static string connectionString;

        static DatabaseHelper()
        {
          
            connectionString = ConfigurationManager.ConnectionStrings["PhumlaKamnandiConnection"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ConfigurationErrorsException("Connection string 'PhumlaKamnandiConnection' not found in App.config");
            }

           
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string dataDirectory;

          
            if (baseDir.Contains("\\bin\\Debug") || baseDir.Contains("\\bin\\Release"))
            {
            
                dataDirectory = Path.GetFullPath(Path.Combine(baseDir, @"..\..\Database"));
            }
            else
            {
               
                dataDirectory = Path.Combine(baseDir, "Database");
            }

            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }

            AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectory);
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}