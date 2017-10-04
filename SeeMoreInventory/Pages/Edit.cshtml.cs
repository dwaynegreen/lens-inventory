using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeeMoreInventory.Models;

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

        [BindProperty]
        public string selectedMaterial { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lens = await _context.Lenses.Include(m => m.Material).SingleOrDefaultAsync(m => m.ProductLabel == id);

            List<MaterialType> materials = _context.Materials.Where(d => !d.Deleted).ToList();
            List<string> materialNames = new List<string>();
            foreach (MaterialType material in materials)
            {
                materialNames.Add(material.Name);
            }
            if (Lens.Material.Deleted)
            {
                materialNames.Add(Lens.Material.Name);
            }
            Materials = new SelectList(materialNames);



            selectedMaterial = Lens.Material.Name;

            if (Lens == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (String.IsNullOrEmpty(Lens.Material.Name))
            {
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var materialToUpdate = _context.Materials.FirstOrDefault(m => m.Name == Lens.Material.Name);
                if (materialToUpdate != null)
                {
                    Lens.Material = materialToUpdate;
                }
                _context.Entry(Lens).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return RedirectToPage("./Inventory");
        }

        public async Task<IActionResult> OnPostDeleteAsync(string productLabel)
        {
            var Lens = await _context.Lenses.FindAsync(productLabel);

            if (Lens != null)
            {
                _context.Lenses.Remove(Lens);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Inventory");
        }
    }
}