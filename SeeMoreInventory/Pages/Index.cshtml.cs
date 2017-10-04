using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeeMoreInventory.Models;
using SeeMoreInventory.ViewModels;

namespace SeeMoreInventory.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LensContext _lensData;
        
        [BindProperty]
        public UpdateInventoryCountViewModel updateInventory { get; set; }

        [BindProperty]
        public List<LensHistory> LensHistory { get; set; }

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
            if (_lensData.ValidateLens(updateInventory.ProductLabel))
            {
                _lensData.DecrementInventory(updateInventory.ProductLabel, updateInventory.Count);
                _lensData.UpdateHistory(updateInventory.ProductLabel, updateInventory.Count);
            }
            await OnGetAsync();
        }
    }
}