using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeeMoreInventory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            List<MaterialType> materials = _context.Materials.Where(m => m.Deleted == false).ToList();
            List<string> materialNames = new List<string>();
            foreach (MaterialType material in materials)
            {
                materialNames.Add(material.Name);   
            }
            Materials = new SelectList(materialNames);
            return Page();
        }

        [BindProperty]
        public Lens Lens { get; set; }

        public SelectList Materials;

        [BindProperty]
        public string SelectedMaterial { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (String.IsNullOrEmpty(SelectedMaterial))
            {
                return Page();
            }
            else
            {
                Lens.Material = _context.GetMaterialByName(SelectedMaterial);
                _context.Lenses.Add(Lens);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
        }
    }
}