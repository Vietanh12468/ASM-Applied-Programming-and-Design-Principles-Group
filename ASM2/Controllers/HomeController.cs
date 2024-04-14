using ASM2.Helpers;
using ASM2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            List<Admin> listUser1 = FileHelper.ReadFileList<Admin>("Data/admins.json");
            Admin loginUser1 = FileHelper.FindObjByEmail(listUser1, email);

            if (LoginHelper.LoginProxy(loginUser1, password) == true)
            {
                HttpContext.Session.SetInt32("UserId", loginUser1.id);
                HttpContext.Session.SetString("UserName", loginUser1.fullName);
                HttpContext.Session.SetString("Role", "Admin");
                return RedirectToAction("Index");
            }

            List<Teacher> listUser2 = FileHelper.ReadFileList<Teacher>("Data/teachers.json");
            Teacher loginUser2 = FileHelper.FindObjByEmail(listUser2, email);

            if (LoginHelper.LoginProxy(loginUser2, password) == true)
            {
                HttpContext.Session.SetInt32("UserId", loginUser2.id);
                HttpContext.Session.SetString("UserName", loginUser2.fullName);
                HttpContext.Session.SetString("Role", "Teacher");
                return RedirectToAction("Index");
            }

            List<Student> listUser3 = FileHelper.ReadFileList<Student>("Data/students.json");
            Student loginUser3 = FileHelper.FindObjByEmail(listUser3, email);

            if (LoginHelper.LoginProxy(loginUser3, password) == true)
            {
                HttpContext.Session.SetInt32("UserId", loginUser3.id);
                HttpContext.Session.SetString("UserName", loginUser3.fullName);
                HttpContext.Session.SetString("Role", "Student");
                return RedirectToAction("Index");
            }

            ViewBag.error = "Invalid user";
            return View();

        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
