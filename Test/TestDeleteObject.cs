using ASM2.Helpers;
using ASM2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestDeleteObject<T> where T : User
    {
        public void TestDelete1Object_ReturnsCorrectNumberOfObjects(string filePath, int idToDelete)
        {
            // Arrange
            // using class ReadFileList to read total objects of a list
            List<T> resultListBeforeDelete = FileHelper.ReadFileList<T>(filePath);

            // Count total objects before delete
            int totalObjectsBeforeDelete = resultListBeforeDelete.Count;

            // create class deleteHelper for the object
            DeleteHelper<T> deleteHelper = new DeleteHelper<T>();

            // Act
            // using class DeleteHelper to delete object
            deleteHelper.DeleteObj(filePath, idToDelete);

            // using class ReadFileList to read total objects of a list
            List<T> resultListAfterDelete = FileHelper.ReadFileList<T>(filePath);

            // Count total objects after delete
            int totalObjectsAfterDelete = resultListAfterDelete.Count;

            // Assert

            // Check if the object is deleted
            Assert.Equal(totalObjectsBeforeDelete - 1, totalObjectsAfterDelete);

        }
    }
}
