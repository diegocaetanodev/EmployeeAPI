using Dapper;
using EmployeeAPI.Repositories;
using Moq;
using Moq.Dapper;
using System.Data;

namespace EmployeeAPI.Tests.Repositories
{
    public class EmployeeRepositoryTests
    {
        [Fact]
        public async Task GetEmployee_ReturnsEmployeeName_WhenEmployeeExists()
        {
            // Arrange
            var dbConnectionMock = new Mock<IDbConnection>();
            var expectedName = "Maria";

            dbConnectionMock
                .SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<string>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    null, null, null))
                .ReturnsAsync(expectedName);

            var repository = new EmployeeRepository(dbConnectionMock.Object);

            // Act
            var result = await repository.GetEmployee(expectedName);

            // Assert
            Assert.Equal(expectedName, result);
        }
    }
}