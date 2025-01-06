using Automation.Core.Helpers;
using PhucDH4_MockProject.Model;
using PhucDH4_MockProject.SqlQueries;

namespace PhucDH4_MockProject.Services
{
    public class DatabaseService
    {
        string connectionString = ConfigurationHelper.GetValue<string>("connectionstring");
        public Course GetInformation()
        {
            {
                string queryTemp = Queries.queryTemp;
                var result = SqlHelper.ExecuteQuery<Course>(connectionString, queryTemp);
                return result.FirstOrDefault();
            }
        }
    }
}
