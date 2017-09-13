using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeeMoreInventory.Models;

namespace SeeMoreInventory.Pages.LensPages
{
    public class IndexModel : PageModel
    {
        private readonly LensContext _context;

        public IndexModel(LensContext context)
        {
            _context = context;
        }

        public IList<Lens> Lens { get;set; }

        public async Task OnGetAsync()
        {
            Lens = await _context.Lenses.ToListAsync();
        }
    }
}
