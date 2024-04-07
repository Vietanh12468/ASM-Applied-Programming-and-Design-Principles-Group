using ASM2.Helpers;
using ASM2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Text.Json;


namespace ASM2.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Create()
        {
            List<Major>? majors = FileHelper.ReadFileList<Major>("Data/majors.json");
            ViewBag.Majors = majors;
            return View();
        }

        [HttpPost]
        public IActionResult Create(string email, string fullname, string phone, string gender, DateOnly DOB, string role, string major)
        {
            switch (role)
            {
                case "Teacher":
                    CreateUserHelper.CreateUser<Teacher>(email, fullname, phone, gender, DOB, "Data/teachers.json");
                    break;
                case "Admin":
                    CreateUserHelper.CreateUser<Admin>(email, fullname, phone, gender, DOB, "Data/admins.json");
                    break;
                default:
                    CreateUserHelper.CreateUser<Student>(email, fullname, phone, gender, DOB, major, "Data/students.json");
                    break;
            }
            return RedirectToAction("Search");
        }

        [HttpGet]
        public IActionResult Search()
        {
            List<Student>? students = FileHelper.ReadFileList<Student>("Data/students.json");
            ViewBag.users = students;
            return View();
        }

        [HttpPost]
        public IActionResult Search(string keyword, string role)
        {
            switch (role)
            {
                case "Teacher":
                    List<Teacher>? teachers = FileHelper.ReadFileList<Teacher>("Data/teachers.json");
                    UserSearchHelper<Teacher> searchHelperTeacher = new UserSearchHelper<Teacher>();
                    List<Teacher> searchResultTeacher = searchHelperTeacher.SearchList(teachers, keyword);
                    ViewBag.users = searchResultTeacher;
                    return View();
                case "Admin":
                    List<Admin>? admins = FileHelper.ReadFileList<Admin>("Data/admins.json");
                    UserSearchHelper<Admin> searchHelperAdmin = new UserSearchHelper<Admin>();
                    List<Admin> searchResultAdmin = searchHelperAdmin.SearchList(admins, keyword);
                    ViewBag.users = searchResultAdmin;
                    return View();
                default:
                    List<Student>? students = FileHelper.ReadFileList<Student>("Data/students.json");
                    UserSearchHelper<Student> searchHelperStudent = new UserSearchHelper<Student>();
                    List<Student> searchResultStudent = searchHelperStudent.SearchList(students, keyword);
                    ViewBag.users = searchResultStudent;
                    return View();
            }
        }
    }
}
