using ASM2.Models;
using Microsoft.AspNetCore.Http;
using System;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;
using ASM2.Helpers;
using System.Numerics;
using System.Globalization;

namespace Test
{
    public class TestReadFile<T> where T : User, new()
    {
        public void ReadFileList_ReturnsCorrectNumberOfObjects(string filePath, int expectedTotalObjects)
        {
            // Arrange

            // Act
            List<T> result = FileHelper.ReadFileList<T>(filePath);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedTotalObjects, result.Count);
        }

        public void TestCreateNewUser_CompareTheResult(string filePath, string expectedName, string expectedEmail, string expectedDOB, string expectedPhone, string expectedGender)
        {
            // Arrange

            // Act
            CreateUserHelper.CreateUser<T>(expectedEmail, expectedName, expectedPhone, expectedGender, DateOnly.ParseExact(expectedDOB, "yyyy-MM-dd"), filePath);

            List<T> result = FileHelper.ReadFileList<T>(filePath);
            T firstObj = result[result.Count - 1];

            // Assert
            Assert.Equal(expectedName, firstObj.fullName);
            Assert.Equal(expectedEmail, firstObj.email);
            Assert.Equal(expectedDOB, firstObj.DOB.ToString("yyyy-MM-dd"));
            Assert.Equal(expectedPhone, firstObj.phone);
            Assert.Equal(expectedGender, firstObj.gender);
        }

        public void TestReadFileList_ReadFirstObj(string filePath, int expectedID, string expectedName, string expectedEmail, string expectedDOB, string expectedPhone, string expectedGender)
        {
            // Arrange

            // Act
            List<T> result = FileHelper.ReadFileList<T>(filePath);
            T firstObj = result[0];

            // Assert
            Assert.Equal(expectedID, firstObj.id);
            Assert.Equal(expectedName, firstObj.fullName);
            Assert.Equal(expectedEmail, firstObj.email);
            Assert.Equal(expectedDOB, firstObj.DOB.ToString("yyyy-MM-dd"));
            Assert.Equal(expectedPhone, firstObj.phone);
            Assert.Equal(expectedGender, firstObj.gender);
        }
    }
}
