using Microsoft.AspNetCore.Mvc;
using ASM2.Controllers;
using ASM2.Models;

namespace ASM2.Tests
{
    public class MajorControllerTests
    {
        [Fact]
        public void Create_ReturnsOkResult_WhenValidMajor()
        {
            // Arrange
            var dbContext = new Context(); // Create an in-memory DbContext for testing
            var controller = new MajorController(dbContext);
            var major = new Major { Name = "Test Major" };

            // Act
            var result = controller.Create(major) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value as Major);
        }
    }
}

