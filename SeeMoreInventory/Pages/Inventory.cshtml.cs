using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public IList<Lens> Lenses { get; set; }

        [BindProperty]
        public LabelViewModel LabelViewModel { get; set; }

        public InventoryModel(LensContext context)
        {
            _lensData = context;
        }

        public void OnGet()
        {
            Lenses = _lensData.Lenses.ToList();
        }

        public IActionResult GnerateCSV()
        {
            return Page();
        }
    }
}