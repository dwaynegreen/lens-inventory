using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using SeeMoreInventory.Models;

namespace SeeMoreInventory.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Lens> Lenses { get; set; }
        public IEnumerable<LensHistory> History { get; set; }
    }
}