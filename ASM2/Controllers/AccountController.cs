using ASM2.Helpers;
using ASM2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;


namespace ASM2.Controllers
{
    public class AccountController : Controller
    {
        List<Teacher>? teachers = FileHelper.ReadFileList<Teacher>("Data/teachers.json");
        List<Admin>? admins = FileHelper.ReadFileList<Admin>("Data/admins.json");
        List<Student>? students = FileHelper.ReadFileList<Student>("Data/students.json");
        List<Major>? majors = FileHelper.ReadFileList<Major>("Data/majors.json");

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Majors = majors;
            return View();
        }

        [HttpPost]
        public IActionResult Create(string email, string fullname, string phone, string gender, DateOnly DOB, string role, string major)
        {
            switch (role)
            {
                case "Teacher":
                    Teacher teacher = new Teacher();
                    CreateUserHelper.CreateUser(teachers, email, fullname, phone, gender, DOB, teacher, "Data/teachers.json");
                    break;
                case "Admin":
                    Admin admin = new Admin();
                    CreateUserHelper.CreateUser(admins, email, fullname, phone, gender, DOB, admin, "Data/admins.json");
                    break;
                default:
                    Student student = new Student();
                    CreateUserHelper.CreateUser(students, email, fullname, phone, gender, DOB, major, student, "Data/students.json");
                    break;
            }
            return RedirectToAction("Search");
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
/*
        [HttpPost]
        public IActionResult Search(string keyword)
        {
            UserSearchHelper searchHelper = new UserSearchHelper();
            List<User> searchResult = searchHelper.SearchList(users, keyword);
            return View(searchResult);
        }*/



    }

}
