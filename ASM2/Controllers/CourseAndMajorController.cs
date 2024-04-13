using Microsoft.AspNetCore.Mvc;
using ASM2.Helpers;
using ASM2.Models;

namespace ASM2.Controllers
{
    public class CourseAndMajorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCourse(Course course) 
        {
            List<Course> courses = FileHelper.ReadFileList<Course>("Data/courses.json");
            courses.Add(course);
            FileHelper.AddToJson(courses, "Data/courses.json");
            TempData["AlertMessage"] = "Course created successfully.";
            return View();
        }

        [HttpGet]
        public IActionResult CreateMajor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMajor(Major major)
        {
            List<Major> majors = FileHelper.ReadFileList<Major>("Data/majors.json");
            majors.Add(major);
            FileHelper.AddToJson(majors, "Data/majors.json");
            // send a alert success created
            TempData["AlertMessage"] = "Major created successfully.";
            return View();
        }
    }
}
