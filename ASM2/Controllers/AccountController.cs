using ASM2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace ASM2.Controllers
{
    public class AccountController : Controller
    {
        static List<User>? users = new List<User>();
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            users.Add(user);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(users, options);
            using (StreamWriter writer = new StreamWriter("users.json")) { 
                writer.Write(jsonString);
            }
            return Content(jsonString);
        }

        public IActionResult RegistrationSuccess()
        {
            return View();
        }
    }

}
