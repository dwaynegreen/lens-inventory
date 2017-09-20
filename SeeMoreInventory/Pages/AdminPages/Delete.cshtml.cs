using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeeMoreInventory.Models;

namespace SeeMoreInventory.Pages.AdminPages
{
    public class AdminDeleteModel : PageModel
    {
        private readonly LensContext _lensdata;

        [BindProperty]
        public MaterialType Material { get; set; }

        public AdminDeleteModel(LensContext context)
        {
            _lensdata = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Material = await _lensdata.Materials.SingleOrDefaultAsync(m => m.Id == id);

            if (Material == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Material = await _lensdata.Materials.FindAsync(id);

            if (Material != null)
            {
                Material.Deleted = true;
                await _lensdata.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}