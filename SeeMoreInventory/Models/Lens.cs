using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeeMoreInventory.Models
{
    public class Lens
    {
        public Lens()
        { }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(30, ErrorMessage = "Product Labels cannot be longer than 30 characters")]
        [Display(Name = "Product Label")]
        public string ProductLabel { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal Sphere { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        [Range(-8.00, 0.00)]
        public decimal Cylinder { get; set; }

        public bool AntiReflectiveCoating { get; set; }

        [Required]
        public MaterialType Material { get; set; }

        public bool Transitions { get; set; }

        public int? RemainingCount { get; set; }

        public int? LowInventoryWarning { get; set; }
    }
}