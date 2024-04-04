using ASM2.Helpers;
using ASM2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASM2.Controllers
{
    public class ClassController : Controller
    {
        List<User>? users = FileHelper.ReadFileList<User>("users.json");
        List<Class>? classes = FileHelper.ReadFileList<Class>("classes.json");

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Users = users;
            return View();
        }
        [HttpPost]
        public IActionResult SearchUser(string keyword, string searchType)
        {
            UserSearchHelper searchHelper = new UserSearchHelper();
            List<User> searchResult = searchHelper.SearchList(users, keyword, searchType);
            ViewBag.Users = searchResult;
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Class cls)
        {
            classes.Add(cls);
            FileHelper.AddToList(classes, "classes.json");
            return RedirectToAction("Search");
        }

    }
}
