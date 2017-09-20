using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeeMoreInventory.Models;

namespace SeeMoreInventory.Pages.AdminPages
{
    public class CreateModel : PageModel
    {

        public readonly LensContext _lensData;

        [BindProperty]
        public MaterialType Material { get; set; }

        public CreateModel(LensContext context)
        {
            _lensData = context;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _lensData.Materials.Add(Material);
            _lensData.SaveChanges();
            return Redirect("/AdminPages/Index");
        }
    }
}