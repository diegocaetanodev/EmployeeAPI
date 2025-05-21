using EmployeeAPI.Interfaces;
using EmployeeAPI.UseCase;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeAPI.Tests.UseCase
{
    public class GetEmployeeUseCaseTests
    {
        [Fact]
        public async Task GetEmployee_ReturnsEmployeeName_WhenEmployeeExists()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            var employeeName = "Maria";
            mockRepository.Setup(r => r.GetEmployee(employeeName)).ReturnsAsync(employeeName);

            var useCase = new GetEmployeeUseCase(mockRepository.Object);

            // Act
            var result = await useCase.GetEmployee(employeeName);

            // Assert
            Assert.Equal(employeeName, result);
        }

        [Fact]
        public async Task GetEmployee_ReturnsNull_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            var employeeName = "Inexistente";
            mockRepository.Setup(r => r.GetEmployee(employeeName)).ReturnsAsync((string?)null);

            var useCase = new GetEmployeeUseCase(mockRepository.Object);

            // Act
            var result = await useCase.GetEmployee(employeeName);

            // Assert
            Assert.Null(result);
        }
    }
}