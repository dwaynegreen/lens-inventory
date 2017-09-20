using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeeMoreInventory.Models;

namespace SeeMoreInventory.Pages.AdminPages
{
    public class AdminIndexModel : PageModel
    {
        private readonly LensContext _lensData;

        [BindProperty]
        public List<MaterialType> Materials { get; set; }

        public AdminIndexModel(LensContext context)
        {
            _lensData = context;
        }

        public void OnGet()
        {
            Materials = _lensData.Materials.Where(m => m.Deleted == false).ToList();
        }
    }
}