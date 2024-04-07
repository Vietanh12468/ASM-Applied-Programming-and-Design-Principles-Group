using ASM2.Models;
using System.Collections.Generic;
using System.Reflection;

namespace ASM2.Helpers
{
    public static class CreateUserHelper
    {
        public static void CreateUser<T>(string email, string fullname, string phone, string gender, DateOnly DOB, string filePath) where T : User, new()
        {
            List<T> listUsers = FileHelper.ReadFileList<T>(filePath);
            int id = FileHelper.ReadLastId<T>(listUsers) + 1;
            T user = new T();
            user.CreateUser(id, DOB, fullname, email, phone, gender);
            listUsers.Add(user);
            FileHelper.AddToList(listUsers, filePath);
        }
        public static void CreateUser<T>(string email, string fullname, string phone, string gender, DateOnly DOB, string major, string filePath) where T : Student, new()
        {
            List<T> listUsers = FileHelper.ReadFileList<T>(filePath);
            int id = FileHelper.ReadLastId<T>(listUsers) + 1;
            T user = new T();
            user.CreateUser(id, DOB, fullname, email, phone, gender);
            user.major = major;
            listUsers.Add(user);
            FileHelper.AddToList(listUsers, filePath);
        }
    }
}
