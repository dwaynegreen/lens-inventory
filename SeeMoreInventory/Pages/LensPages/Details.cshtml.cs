using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeeMoreInventory.Models;

namespace SeeMoreInventory.Pages.LensPages
{
    public class DetailsModel : PageModel
    {
        private readonly LensContext _context;

        public DetailsModel(LensContext context)
        {
            _context = context;
        }

        public Lens Lens { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lens = await _context.Lenses.SingleOrDefaultAsync(m => m.ProductLabel == id);

            if (Lens == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
