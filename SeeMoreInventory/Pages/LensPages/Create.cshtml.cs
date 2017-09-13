using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeeMoreInventory.Models;

namespace SeeMoreInventory.Pages.LensPages
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

        [HttpPost]
        public JsonResult UniqueProduct(string productLabel)
        {
            //if (!_context.UniqueProduct(productLabel))
            //{
            //    return Json(data: $"Product Label {productLabel} is already in use.");
            //}
            //return Json(data: true);
            return new JsonResult(productLabel);
        }
    }
}