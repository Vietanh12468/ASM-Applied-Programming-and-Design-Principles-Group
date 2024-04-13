using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASM2.Models;

namespace ASM2.Pages.Course
{
    public class CreateCourse : PageModel
    {
        private readonly CourseContext _context; // Replace YourDbContext with your actual DbContext

        public CreateCourse(CourseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course course { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Courses.Add(course);
            _context.SaveChanges(); // Save changes to the database using DbContext

            return RedirectToPage("/Index"); // Redirect to a different page after creating the course
        }
    }

    internal class CourseContext
    {
        public object Courses { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
