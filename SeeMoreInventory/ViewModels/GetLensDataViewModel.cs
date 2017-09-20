using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeMoreInventory.ViewModels
{

    public class GetLensDataViewModel
    {
        public string ProductLabel { get; set; }
        public string Sphere { get; set; }
        public string Cylinder { get; set; }
        public string Axis { get; set; }
        public string Coatings { get; set; }
        public string Material { get; set; }
        public string RemainingCount { get; set; }
        public bool Success { get; set; }
    }
}
