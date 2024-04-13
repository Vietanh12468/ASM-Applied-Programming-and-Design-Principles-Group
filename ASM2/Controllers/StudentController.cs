using ASM2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ASM2.Helpers;

namespace ASM2.Controllers
{
    public class StudentController : Controller
    {
        List<Student> students = FileHelper.ReadFileList<Student>("Data/students.json");
        [HttpGet]
        public IActionResult Create()
        {
            /*ViewBag.Users = users;*/
            ViewBag.Student = students;
            return View();
        }
        [HttpGet]
        public IActionResult List()
        {
            ViewBag.students = students;
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            Student student = students.Find(s => s.id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
