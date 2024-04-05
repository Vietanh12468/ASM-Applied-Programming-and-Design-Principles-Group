using ASM2.Models;
using System.Reflection;

namespace ASM2.Helpers
{
    public static class CreateUserHelper
    {
        public static void CreateUser<T>(List<T>? list, string email, string fullname, string phone, string gender, DateOnly DOB, T obj, string filePath) where T : User
        {
            obj.id = FileHelper.ReadLastId<T>(list);
            obj.DOB = DOB;
            obj.fullName = fullname;
            obj.email = email;
            obj.phone = phone;
            obj.gender = gender;
            list.Add(obj);
            FileHelper.AddToList(list, filePath);
        }
        public static void CreateUser<T>(List<T>? list, string email, string fullname, string phone, string gender, DateOnly DOB, string major, T obj, string filePath) where T : Student
        {
            obj.id = FileHelper.ReadLastId<T>(list);
            obj.DOB = DOB;
            obj.fullName = fullname;
            obj.email = email;
            obj.phone = phone;
            obj.gender = gender;
            obj.major = major;
            list.Add(obj);
            FileHelper.AddToList(list, filePath);
        }
    }
}
