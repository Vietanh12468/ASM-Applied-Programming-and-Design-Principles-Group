using ASM2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASM2.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            // Process the registration data here
            // You can access the form values from the `model` parameter

            // Redirect to a success page or perform other actions
            return RedirectToAction("Register");
        }

        public IActionResult RegistrationSuccess()
        {
            return View();
        }
    }

    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public string Major { get; set; }
    }
}
