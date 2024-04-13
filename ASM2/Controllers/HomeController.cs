using ASM2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace ASM2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login()
        {
            return View();
        }
        public class User
        {
            public string fullName { get; set; }
            public string email { get; set; }

        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            // Search for the user in students.json
            var studentAccounts = GetAccounts("students.json");
            var studentMatch = studentAccounts.FirstOrDefault(u => u.fullName == user.fullName && u.email == user.email);

            if (studentMatch != null)
            {
                TempData["SuccessMessage"] = "Login successful!";
                return RedirectToAction("Index", "Home");
            }

            // Search for the user in teachers.json
            var teacherAccounts = GetAccounts("teachers.json");
            var teacherMatch = teacherAccounts.FirstOrDefault(u => u.fullName == user.fullName && u.email == user.email);

            if (teacherMatch != null)
            {
                TempData["SuccessMessage"] = "Login successful!";
                return RedirectToAction("Index", "Home");
            }

            // Search for the user in admins.json
            var adminAccounts = GetAccounts("admins.json");
            var adminMatch = adminAccounts.FirstOrDefault(u => u.fullName == user.fullName && u.email == user.email);

            if (adminMatch != null)
            {
                TempData["SuccessMessage"] = "Login successful!";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Login failed. Invalid username or password.";
            return View("Index", user);
        }

        // Helper method to read JSON file and deserialize into list of User objects
        private List<User> GetAccounts(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", fileName);
            var json = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<User>>(json); 
        }
    }
}
