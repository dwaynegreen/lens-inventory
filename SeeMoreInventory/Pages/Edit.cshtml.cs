using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeeMoreInventory.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace SeeMoreInventory.Pages
{
    public class EditModel : PageModel
    {
        private readonly LensContext _context;

        public EditModel(LensContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lens Lens { get; set; }

        public SelectList Materials;

        public string selectedMaterial;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<MaterialType> materials = _context.Materials.Where(d => !d.Deleted).ToList();
            List<string> materialNames = new List<string>();
            foreach (MaterialType material in materials)
            {
                materialNames.Add(material.Name);
            }
            Materials = new SelectList(materialNames);

           

            Lens = await _context.Lenses.SingleOrDefaultAsync(m => m.ProductLabel == id);

            selectedMaterial = Lens.Material.Name;

            if (Lens == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (String.IsNullOrEmpty(selectedMaterial))
            {
                return Page();
            }
            else
            {
                Lens.Material = _context.GetMaterialByName(selectedMaterial);
            }


            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.Attach(Lens).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return RedirectToPage("./Inventory");
        }
    }
}
