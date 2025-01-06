using PhucDH4_MockProject.Services;

namespace PhucDH4_MockProject.Tests.TestDatabase
{
    [TestClass]
    public class DatabaseTest : BaseTest
    {
        DatabaseService databaseService;

        public DatabaseTest()
        {
            databaseService = new DatabaseService();
        }

        [TestMethod("Test case 1: Validate that the databaseService retrieves the correct course information.")]
        public void TestDatabase()
        {
            // Step 1: Call the database service to retrieve information.
            var result = databaseService.GetInformation();

            // Step 2: Verify that the Name and IdCourse field matches the expected values.
            Assert.AreEqual(result.Name, "SQL Basic");
            Assert.AreEqual(result.IdCourse, 1);
        }
    }
}

