using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeeMoreInventory.Models;

namespace SeeMoreInventory.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LensContext _lensData;

        public IList<LensHistory> LensHistory { get; set; }

        public IndexModel(LensContext lensData)
        {
            _lensData = lensData;
        }

        public async Task OnGetAsync()
        {
            LensHistory = await _lensData.LensHistory.ToListAsync();
        }
    }
}