using Microsoft.AspNetCore.Mvc;
using ASM2.Models; // Assuming Course model exists in Models folder

namespace ASM2.Controllers
{
    public class CourseController : Controller
    {
        private readonly Context _context; // Replace YourDbContext with your actual DbContext

        public CourseController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Courses.Add(course);
            _context.SaveChanges();

            return Ok(course);
        }
    }
}
