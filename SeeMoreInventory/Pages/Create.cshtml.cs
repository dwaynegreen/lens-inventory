using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeeMoreInventory.Models;

namespace SeeMoreInventory.Pages
{
    public class CreateModel : PageModel
    {
        private readonly LensContext _context;

        public CreateModel(LensContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Lens Lens { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Lenses.Add(Lens);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}