using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeeMoreInventory.Models;
using SeeMoreInventory.ViewModels;
using Newtonsoft.Json;
using System.Linq;

namespace SeeMoreInventory.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LensContext _lensData;
        
        [BindProperty]
        public UpdateInventoryCountViewModel updateInventory { get; set; }

        [BindProperty]
        public IList<LensHistory> LensHistory { get; set; }

        public IndexModel(LensContext lensData)
        {
            _lensData = lensData;
        }

        public async Task OnGetAsync()
        {
            LensHistory = await _lensData.GetTodaysHistory().ToListAsync();
        }

        public async Task OnPostAsync()
        {
            if (_lensData.ValidateLens(updateInventory.id))
            {
                _lensData.DecrementInventory(updateInventory.id, updateInventory.count);
                _lensData.UpdateHistory(updateInventory.id, updateInventory.count);
            }

            await OnGetAsync();
        }
    }
}