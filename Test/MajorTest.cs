using ASM2.Controllers;
using ASM2.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;

namespace Major.Tests.Controllers
{
    [TestFixture]
    public class CourseAndMajorControllerTests
    {
        [Test]
        public void CreateMajor_Post_ReturnsRedirectToAction()
        {
            // Arrange
            var mockTempData = new TempDataDictionary();
            var mockMajorService = new Mock<IMajorService>(); // Assuming you have a service for handling majors
            var controller = new CourseAndMajorController(mockMajorService.Object)
            {
                TempData = mockTempData
            };
            var model = new Major();

            // Act
            var result = controller.CreateMajor(model) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]); // Assuming it redirects to the Index action after creating a major
        }
    }
}
