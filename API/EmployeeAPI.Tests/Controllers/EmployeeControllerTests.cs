using EmployeeAPI.Controllers;
using EmployeeAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeAPI.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        [Fact]
        public void Get_ReturnsOk_WhenEmployeeExists()
        {
            // Arrange
            var mockUseCase = new Mock<IGetEmployeeUseCase>();
            var employeeName = "Maria";
            mockUseCase.Setup(u => u.GetEmployee(employeeName)).ReturnsAsync(employeeName);

            var controller = new EmployeeController(mockUseCase.Object);

            // Act
            var result = controller.Get(employeeName);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Hello, Maria", okResult.Value);
        }

        [Fact]
        public void Get_ReturnsNotFound_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var mockUseCase = new Mock<IGetEmployeeUseCase>();
            var employeeName = "Inexistente";
            mockUseCase.Setup(u => u.GetEmployee(employeeName)).ReturnsAsync((string?)null);

            var controller = new EmployeeController(mockUseCase.Object);

            // Act
            var result = controller.Get(employeeName);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("User not found.", notFoundResult.Value);
        }

        [Fact]
        public void Get_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            var mockUseCase = new Mock<IGetEmployeeUseCase>();
            var employeeName = "Erro";
            mockUseCase.Setup(u => u.GetEmployee(employeeName)).ThrowsAsync(new Exception());

            var controller = new EmployeeController(mockUseCase.Object);

            // Act
            var result = controller.Get(employeeName);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            
        }
    }
}
