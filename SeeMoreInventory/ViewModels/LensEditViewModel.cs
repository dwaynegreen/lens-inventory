using System.ComponentModel.DataAnnotations;
using SeeMoreInventory.Models;

namespace SeeMoreInventory.ViewModels
{
    public class LensEditViewModel
    {
        [Required(ErrorMessage = "Please enter your Product Label")]
        [Display(Name = "Product Label")]
        [StringLength(30)]
        public string ProductLabel { get; set; }
        [DisplayFormat(DataFormatString = "0.00")]
        public decimal Sphere { get; set; }
        [DisplayFormat(DataFormatString = "0.00")]
        public decimal Cylinder { get; set; }
        public int? Axis { get; set; }
        public bool AntiReflectiveCoating { get; set; }
        public bool Transitions { get; set; }
        public MaterialType Material { get; set; }
        [Required(ErrorMessage = "Please enter a starting inventory value")]
        [Display(Name = "Starting Inventory")]
        [Range(0, int.MaxValue)]
        public int? RemainingCount { get; set; }
        public int LowInventoryWarning { get; set; }
    }
}