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
            List<T> resultListBeforeDelete = FileHelper.ReadFileList<T>(filePath);
            int totalObjectsBeforeDelete = resultListBeforeDelete.Count;
            DeleteHelper<T> deleteHelper = new DeleteHelper<T>();

            // Act
            deleteHelper.DeleteObj(filePath, idToDelete);
            List<T> resultListAfterDelete = FileHelper.ReadFileList<T>(filePath);
            int totalObjectsAfterDelete = resultListAfterDelete.Count;

            // Assert
            Assert.Equal(totalObjectsBeforeDelete - 1, totalObjectsAfterDelete);

        }
    }
}
