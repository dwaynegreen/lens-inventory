using System.ComponentModel.DataAnnotations;

namespace SeeMoreInventory.ViewModels
{
    public class UpdateInventoryCountViewModel
    {
        [Display(Name = "Product Label")]
        public string ProductLabel { get; set; }
        [Display(Name = "Quantity")]
        public int Count { get; set; }
    }
}
