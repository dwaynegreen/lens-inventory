using System.ComponentModel.DataAnnotations;

namespace SeeMoreInventory.Models
{
    public class MaterialType
    {
        [Key]
        [Required]
        public int MaterialId { get; set; }
        public string Name { get; set; }
    }
}
