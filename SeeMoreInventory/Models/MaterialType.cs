using System.ComponentModel.DataAnnotations;

namespace SeeMoreInventory.Models
{
    public class MaterialType
    {
        public MaterialType()
        { }
        public int Id { get; set; }
      
        [Required]
        [Display(Name="Material Name")]
        public string Name { get; set; }

        public bool Deleted { get; set; }
    }
}