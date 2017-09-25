using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SeeMoreInventory.Models;
using SeeMoreInventory.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SeeMoreInventory.Pages
{
    public class InventoryModel : PageModel
    {
        private readonly LensContext _lensData;

        [BindProperty]
        public IIncludableQueryable<Lens, MaterialType> Lenses { get; set; }

        [BindProperty]
        public LabelViewModel LabelViewModel { get; set; }

        public InventoryModel(LensContext context)
        {
            _lensData = context;
            var lenses = _lensData.Lenses.Include(i => i.Material);
            Lenses = lenses;
        }

        public void OnGet()
        {
            
        }

        public IActionResult GnerateCSV()
        {
            return Page();
        }
    }
}