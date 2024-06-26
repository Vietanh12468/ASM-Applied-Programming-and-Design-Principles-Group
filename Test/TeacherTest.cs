﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASM2.Models;
namespace Test
{
    public class TeacherTest : TestReadFile<Teacher>
    {
        TestDeleteObject<Teacher> testDeleteObject = new TestDeleteObject<Teacher>();

        [Theory]
        [InlineData("Data/teachers.json", "Michael Johnson", "michaeljohnson@example.com", "1983-07-15", "+1 123-456-7890", "Male")]
        public void PassTheParameterToTestReadFirstObj(string filePath, string expectedName, string expectedEmail, string expectedDOB, string expectedPhone, string expectedGender)
        {
            TestReadFileList_ReadFirstObj(filePath, 1, expectedName, expectedEmail, expectedDOB, expectedPhone, expectedGender);
        }

        [Theory]
        [InlineData("Data/teachers.json", 5)]
        public void PassTheParameterToReturnsCorrectNumberOfObjects(string filePath, int expectedTotalObjects)
        {
            ReadFileList_ReturnsCorrectNumberOfObjects(filePath, expectedTotalObjects);
        }

        [Theory]
        [InlineData("Data/teachers.json", "VA", "VA@example.com", "2007-07-15", "+1 123-456-7890", "Male")]
        public void PassTheParameterToTestCreateNewUser(string filePath, string expectedName, string expectedEmail, string expectedDOB, string expectedPhone, string expectedGender)
        {
            TestCreateNewUser_CompareTheResult(filePath, expectedName, expectedEmail, expectedDOB, expectedPhone, expectedGender);
        }

        [Theory]
        [InlineData("Data/teachers.json", 6)]
        public void TestDelete1Object_ReturnsCorrectNumberOfObjects(string filePath, int idToDelete)
        {
            testDeleteObject.TestDelete1Object_ReturnsCorrectNumberOfObjects(filePath, idToDelete);
        }
    }
}
