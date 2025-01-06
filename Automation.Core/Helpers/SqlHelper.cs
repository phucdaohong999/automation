using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Automation.Core.Helpers
{
    public static class SqlHelper
    {
        private static int sqlTimeOut = ConfigurationHelper.GetValue<int>("sqltimeout");
        public static List<T> ExecuteQuery<T>(string connectionStr, string query, int? timeout = null) where T : new()
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                // Use the provided timeout or fallback to sqlTimeOut
                int effectiveTimeout = timeout ?? sqlTimeOut;
                return connection.Query<T>(query, commandTimeout: timeout).ToList();
            }
        }
        public static void ExecuteMultipleQueries(string connectionStr, params string[] queries)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionStr))
                {
                    foreach (var query in queries)
                    {
                        connection.Execute(query); // Execute the query without fetching results
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log SQL-specific exceptions or rethrow
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Log general exceptions or rethrow
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}


