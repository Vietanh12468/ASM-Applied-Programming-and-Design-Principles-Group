using ASM2.Helpers;
using ASM2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ASM2.Controllers
{
    public class ClassController : Controller
    {
        /*List<User>? users = FileHelper.ReadFileList<User>("users.json");*/
        List<Class>? classes = FileHelper.ReadFileList<Class>("Data/classes.json");
        List<Teacher> teachers = FileHelper.ReadFileList<Teacher>("Data/teachers.json");

        [HttpGet]
        public IActionResult Create()
        {
            /*ViewBag.Users = users;*/
            ViewBag.Teacher = teachers;
            ViewBag.Classes = classes;
            return View();
        }
/*        [HttpPost]
        public IActionResult SearchUser(string keyword, string searchType)
        {
            UserSearchHelper searchHelper = new UserSearchHelper();
            List<User> searchResult = searchHelper.SearchList(users, keyword, searchType);
            ViewBag.Users = searchResult;
            return View("Create");
        }*/
        [HttpPost]
        public IActionResult Create(Class cls)
        {
            classes.Add(cls);
            FileHelper.AddToList(classes, "classes.json");
            return RedirectToAction("Search");
        }



        public ClassController()
        {
            // Read data from classes.json file and deserialize it into a list of Class objects
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data/classes.json");
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            classes = JsonSerializer.Deserialize<List<Class>>(jsonData);
        }

        [HttpGet]
        public IActionResult List()
        {
            ViewBag.Classes = classes;
            return View(classes);
        }

        public IActionResult Detail(int id)
        {
            Class cls = classes.FirstOrDefault(c => c.id == id);
            if (cls == null)
            {
                return NotFound();
            }
            return View(cls);
        }
    }
}
