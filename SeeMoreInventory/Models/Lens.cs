﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SeeMoreInventory.Models
{
    public class Lens
    {
        [Key]
        [Required]
        [StringLength(30, ErrorMessage = "Product Labels cannot be longer than 30 characters")]
        [Display(Name = "Product Label")]
        public string ProductLabel { get; set; }

        [DisplayFormat(DataFormatString = "#0.00")]
        public decimal Sphere { get; set; }

        [DisplayFormat(DataFormatString = "#0.00")]
        [Range(0.00, -8.00)]
        public decimal Cylinder { get; set; }

        public int? Axis { get; set; }

        public bool AntiReflectiveCoating { get; set; }

        public MaterialType Material { get; set; }

        public bool Transitions { get; set; }

        public int? RemainingCount { get; set; }

        public int LowInventoryWarning { get; set; }
    }
}