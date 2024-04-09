using ASM2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class StudentTest : TestReadFile<Student>
    {
        TestDeleteObject<Student> testDeleteObject = new TestDeleteObject<Student>();

        [Theory]
        [InlineData("Data/students.json", "John Smith", "johnsmith@example.com", "2000-03-15", "+1 123-456-7890", "Male")]
        public void PassTheParameterToTestReadFirstObj(string filePath, string expectedName, string expectedEmail, string expectedDOB, string expectedPhone, string expectedGender)
        {
            TestReadFileList_ReadFirstObj(filePath, 1, expectedName, expectedEmail, expectedDOB, expectedPhone, expectedGender);
        }

        [Theory]
        [InlineData("Data/students.json", 7)]
        public void PassTheParameterToReturnsCorrectNumberOfObjects(string filePath, int expectedTotalObjects)
        {
            ReadFileList_ReturnsCorrectNumberOfObjects(filePath, expectedTotalObjects);
        }

        [Theory]
        [InlineData("Data/students.json", "VA", "VA@example.com", "2007-07-15", "+1 123-456-7890", "Male")]
        public void PassTheParameterToTestCreateNewUser(string filePath, string expectedName, string expectedEmail, string expectedDOB, string expectedPhone, string expectedGender)
        {
            TestCreateNewUser_CompareTheResult(filePath, expectedName, expectedEmail, expectedDOB, expectedPhone, expectedGender);
        }

        //Create Test Plan for Delete
        [Theory]
        [InlineData("Data/students.json", 8)]
        public void TestDelete1Object_ReturnsCorrectNumberOfObjects(string filePath, int idToDelete)
        {
            testDeleteObject.TestDelete1Object_ReturnsCorrectNumberOfObjects(filePath, idToDelete);
        }
    }
}
