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

        //[HttpPost]
        //public IActionResult Scan([FromBody] UpdateInventoryCountViewModel vm)
        //{
        //    if (!_lensData.ValidateLens(vm.id))
        //        return Page();
        //    if (vm.count < 0)
        //    {
        //        try
        //        {
        //            _lensData.DecrementInventory(vm.id, vm.count);
        //            _lensData.UpdateHistory(vm.id, vm.count);
        //        }
        //        catch (Exception)
        //        {
        //            throw new Exception("Inventory level too low to decrement");
        //        }
        //    }
        //    else if (vm.count > 0)
        //    {
        //        _lensData.IncrementInventory(vm.id, vm.count);
        //        _lensData.UpdateHistory(vm.id, vm.count);
        //    }
        //    return Page();
        //}

        //[HttpGet]
        //public JsonResult GetLensData(string id)
        //{
        //    GetLensDataViewModel lens = new GetLensDataViewModel();
            

        //    if (_lensData.ValidateLens(id))
        //    {
        //        Lens lensData = _lensData.Get(id);

        //        lens.ProductLabel = lensData.ProductLabel;
        //        lens.RemainingCount = lensData.RemainingCount.ToString();
        //        lens.Axis = lensData.Axis == null ? "" : lensData.Axis.ToString();
        //        lens.Cylinder = lensData.Cylinder.ToString();
        //        lens.Material = lensData.Material.ToString();
        //        lens.Sphere = lensData.Sphere.ToString();
        //        lens.Coatings = lensData.AntiReflectiveCoating == false ? "None" : "Anti-Reflective";
        //        lens.Success = true;
        //        return Json(lens);
                
        //    }
        //    else
        //    {
        //        lens.Success = false;
        //        return Json(lens);
        //    }
        //}
    }
}