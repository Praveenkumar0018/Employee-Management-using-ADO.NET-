using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public static class DatabaseHelper
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
