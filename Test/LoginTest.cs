using ASM2.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASM2.Models;

namespace Test
{
    internal class LoginTest
    {
        /*[Fact]
        public void Login_Success_Student()
        {
            // Arrange
            var user = new students { fullName = "John Smith", email = "johnsmith@example.com" };
            var controller = GetHomeControllerInstance();

            // Act
            var result = controller.Login(user);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", (result as RedirectToActionResult).ActionName);
            Assert.Equal("Home", (result as RedirectToActionResult).ControllerName);
        }

        [Fact]
        public void Login_Success_Teacher()
        {
            // Arrange
            var user = new User { fullName = "Teacher Name", email = "teacher@example.com" };
            var controller = GetHomeControllerInstance();

            // Act
            var result = controller.Login(user);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", (result as RedirectToActionResult).ActionName);
            Assert.Equal("Home", (result as RedirectToActionResult).ControllerName);
        }

        [Fact]
        public void Login_Success_Admin()
        {
            // Arrange
            var user = new User { fullName = "Admin Name", email = "admin@example.com" };
            var controller = GetHomeControllerInstance();

            // Act
            var result = controller.Login(user);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", (result as RedirectToActionResult).ActionName);
            Assert.Equal("Home", (result as RedirectToActionResult).ControllerName);
        }

        [Fact]
        public void Login_Failure()
        {
            // Arrange
            var user = new User { fullName = "Unknown User", email = "unknown@example.com" };
            var controller = GetHomeControllerInstance();

            // Act
            var result = controller.Login(user);

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", (result as ViewResult).ViewName);
            Assert.Equal("Login failed. Invalid username or password.", (result as ViewResult).ViewData["Error"]);
        }

        private HomeController GetHomeControllerInstance()
        {
            var mockController = new Mock<HomeController>();
            var mockFilePath = "students.json";
            var mockAccounts = new List<User>
            {
                new User { fullName = "John Doe", email = "john@example.com" }, // Student
                new User { fullName = "Teacher Name", email = "teacher@example.com" }, // Teacher
                new User { fullName = "Admin Name", email = "admin@example.com" } // Admin
            };

            mockController.Setup(c => c.GetAccounts(mockFilePath)).Returns(mockAccounts);

            return mockController.Object;
        }*/

    }

}
