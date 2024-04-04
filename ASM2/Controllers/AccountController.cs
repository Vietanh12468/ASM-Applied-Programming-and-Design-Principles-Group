using ASM2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;


namespace ASM2.Controllers
{
    public class AccountController : Controller
    {
        static List<User>? users = new List<User>();

        public static List<User>? ReadFileList(String filePath)
        {
            // Read a file
            string readText = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<User>>(readText);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            users = ReadFileList("users.json");
            users.Add(user);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(users, options);
            using (StreamWriter writer = new StreamWriter("users.json")) { 
                writer.Write(jsonString);
            }
            return RedirectToAction("Search");
        }

        [HttpGet]
        public IActionResult Search()
        {
            users = ReadFileList("users.json");
            return View(users);
        }

        [HttpPost]
        public IActionResult Search(string keyword)
        {
            List<User> result = new List<User>();
            users = ReadFileList("users.json");
            foreach (var user in users)
            {
                if (user.fullName != null && user.fullName.ToLower().Contains(keyword.ToLower()))
                {
                    result.Add(user);
                }
            }
            return View(result);
        }



    }

}
