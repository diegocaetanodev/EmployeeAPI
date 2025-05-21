using Dapper;
using EmployeeAPI.Interfaces;
using System.Data;

namespace EmployeeAPI.Repositories
{
    public class EmployeeRepository (IDbConnection dbConnection) : IEmployeeRepository
    {

        public async Task<string> GetEmployee(string name)
        {
            // Using parameterized queries with Dapper protects against SQL Injection attacks.
            // Additionally, selecting only the required property (e.g., "Name") instead of using "SELECT *"
            // improves performance and reduces data transfer, as only necessary data is retrieved from the database.
            var sql = "SELECT FirstName FROM Employee WHERE FirstName = @Name";
            var result = await dbConnection.QueryFirstOrDefaultAsync<string>(sql, new { Name = name });
            return result;
        }
    }
}
