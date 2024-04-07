using ASM2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class AdminTest : TestReadFile<Admin>
    {
        [Theory]
        [InlineData("Data/admins.json", "VA", "VA@example.com", "2007-07-15", "+1 123-456-7890", "Male")]
        public void PassTheParameterToTestCreateNewUser(string filePath, string expectedName, string expectedEmail, string expectedDOB, string expectedPhone, string expectedGender)
        {
            TestCreateNewUser_CompareTheResult(filePath, expectedName, expectedEmail, expectedDOB, expectedPhone, expectedGender);
        }

        [Theory]
        [InlineData("Data/admins.json", "John Doe", "johndoe@example.com", "1990-01-01", "+1 123-456-7890", "Male")]
        public void PassTheParameterToTestReadFirstObj(string filePath, string expectedName, string expectedEmail, string expectedDOB, string expectedPhone, string expectedGender)
        {
            TestReadFileList_ReadFirstObj(filePath, 1, expectedName, expectedEmail, expectedDOB, expectedPhone, expectedGender);
        }

        [Theory]
        [InlineData("Data/admins.json", 3)]
        public void PassTheParameterToReturnsCorrectNumberOfObjects(string filePath, int expectedTotalObjects)
        {
            ReadFileList_ReturnsCorrectNumberOfObjects(filePath, expectedTotalObjects);
        }
    }
}
