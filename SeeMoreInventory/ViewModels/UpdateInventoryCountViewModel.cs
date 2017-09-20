using System.ComponentModel.DataAnnotations;

namespace SeeMoreInventory.ViewModels
{
    public class UpdateInventoryCountViewModel
    {
        [Display(Name = "Product Label")]
        public string id { get; set; }
        [Display(Name = "Quantity")]
        public int count { get; set; }
    }
}
