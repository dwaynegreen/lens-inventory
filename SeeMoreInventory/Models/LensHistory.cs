using System;
using System.ComponentModel.DataAnnotations;
namespace SeeMoreInventory.Models
{
    public class LensHistory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Product Labels cannot be longer than 30 characters")]
        [Display(Name = "Product Label")]
        public string ProductLabel { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal Sphere { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        [Range(-10.00, 0.00)]
        public decimal Cylinder { get; set; }

        public int? Axis { get; set; }

        public bool AntiReflectiveCoating { get; set; }

        public MaterialType Material { get; set; }

        public bool Transitions { get; set; }

        public int Quantity { get; set; }

        public int? RemainingCount { get; set; }

        public DateTime InsertDate { get; set; }
    }
}