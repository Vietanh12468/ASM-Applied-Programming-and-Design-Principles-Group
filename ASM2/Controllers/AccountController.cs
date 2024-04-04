using ASM2.Helpers;
using ASM2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;


namespace ASM2.Controllers
{
    public class AccountController : Controller
    {
        List<User>? users = FileHelper.ReadFileList<User>("users.json");
        List<Major>? majors = FileHelper.ReadFileList<Major>("majors.json");

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Majors = majors;
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            users.Add(user);
            FileHelper.AddToList(users, "users.json");
            return RedirectToAction("Search");
        }

        [HttpGet]
        public IActionResult Search()
        {
            ViewBag.Users =users;
            return View();
        }

        [HttpPost]
        public IActionResult Search(string keyword)
        {
            UserSearchHelper searchHelper = new UserSearchHelper();
            List<User> searchResult = searchHelper.SearchList(users, keyword);
            return View(searchResult);
        }



    }

}
