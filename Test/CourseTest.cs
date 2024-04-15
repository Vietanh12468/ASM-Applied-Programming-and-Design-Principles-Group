using ASM2.Controllers;
using ASM2.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;

namespace Course.Tests.Controllers
{
    [TestFixture]
    public class CourseControllerTests
    {
        [Test]
        public void CreateCourse_Post_ReturnsRedirectToAction()
        {
            // Arrange
            var mockTempData = new TempDataDictionary();
            var mockCourseService = new Mock<ICourseService>(); // Assuming you have a service for handling courses
            var controller = new CourseAndMajorController(mockCourseService.Object)
            {
                TempData = mockTempData
            };
            var model = new Course();

            // Act
            var result = controller.CreateCourse(model) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]); // Assuming it redirects to the Index action after creating a course
        }
    }
}

