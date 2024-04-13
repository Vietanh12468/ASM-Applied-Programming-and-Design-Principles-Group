using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASM2.Models; // Assuming Major model exists in Models folder

namespace ASM2.Pages.Major
{
    public class CreateMajorModel : PageModel
    {
        private readonly MajorContext _context; // Replace YourDbContext with your actual DbContext

        public CreateMajorModel(MajorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MajorContext Major { get; set; }

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

            _context.Majors.Add(Major);
            _context.SaveChanges();

            return RedirectToPage("/Index"); // Redirect to a different page after creating the major
        }

        public class MajorContext
        {
        }
    }
}
