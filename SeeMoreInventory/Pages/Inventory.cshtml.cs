using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeeMoreInventory.Models;
using SeeMoreInventory.ViewModels;
using System.Collections.Generic;
using System.Linq;
using SeeMoreInventory.Services;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace SeeMoreInventory.Pages
{
    public class InventoryModel : PageModel
    {
        private readonly LensContext _lensData;
        private CsvWriter csv;
        private IHostingEnvironment _env;

        [BindProperty]
        public IList<Lens> Lenses { get; set; }

        [BindProperty]
        public LabelViewModel LabelViewModel { get; set; }
        //[BindProperty]
        //public bool Box1IsSelected { get; set; }
        //[BindProperty]
        //public bool Box2IsSelected { get; set; }
        //[BindProperty]
        //public bool Box3IsSelected { get; set; }
        //[BindProperty]
        //public bool Box4IsSelected { get; set; }
        //[BindProperty]
        //public bool Box5IsSelected { get; set; }
        //[BindProperty]
        //public bool Box6IsSelected { get; set; }
        //[BindProperty]
        //public bool Box7IsSelected { get; set; }
        //[BindProperty]
        //public bool Box8IsSelected { get; set; }

        //[BindProperty]
        //public string Box1ProductLabel { get; set; }
        //[BindProperty]
        //public string Box2ProductLabel { get; set; }
        //[BindProperty]
        //public string Box3ProductLabel { get; set; }
        //[BindProperty]
        //public string Box4ProductLabel { get; set; }
        //[BindProperty]
        //public string Box5ProductLabel { get; set; }
        //[BindProperty]
        //public string Box6ProductLabel { get; set; }
        //[BindProperty]
        //public string Box7ProductLabel { get; set; }
        //[BindProperty]
        //public string Box8ProductLabel { get; set; }

        public InventoryModel(LensContext context, IHostingEnvironment env)
        {
            _lensData = context;
            _env = env;
        }

        public void OnGet()
        {
            Lenses = _lensData.Lenses.Include(m => m.Material).ToList();
        }

        public IActionResult OnPostPrintLabel()
        {
            Box[] boxesToPrint = new Box[8] { new Box(), new Box(), new Box(), new Box(), new Box(), new Box(), new Box(), new Box() };

            bool[] boxesSelected = new bool[8];
            boxesSelected[0] = !LabelViewModel.Box1IsSelected;
            boxesSelected[1] = !LabelViewModel.Box2IsSelected;
            boxesSelected[2] = !LabelViewModel.Box3IsSelected;
            boxesSelected[3] = !LabelViewModel.Box4IsSelected;
            boxesSelected[4] = !LabelViewModel.Box5IsSelected;
            boxesSelected[5] = !LabelViewModel.Box6IsSelected;
            boxesSelected[6] = !LabelViewModel.Box7IsSelected;
            boxesSelected[7] = !LabelViewModel.Box8IsSelected;


            string[] productLabels = new string[8];

            if (LabelViewModel.Box1ProductLabel != null)
            {
                productLabels[0] = LabelViewModel.Box1ProductLabel;
            }
            else
            {
                boxesSelected[0] = false;
            }
            if (LabelViewModel.Box2ProductLabel != null)
            {
                productLabels[1] = LabelViewModel.Box2ProductLabel;
            }
            else
            {
                boxesSelected[1] = false;
            }
            if (LabelViewModel.Box3ProductLabel != null)
            {
                productLabels[2] = LabelViewModel.Box3ProductLabel;
            }
            else
            {
                boxesSelected[2] = false;
            }
            if (LabelViewModel.Box4ProductLabel != null)
            {
                productLabels[3] = LabelViewModel.Box4ProductLabel;
            }
            else
            {
                boxesSelected[3] = false;
            }
            if (LabelViewModel.Box5ProductLabel != null)
            {
                productLabels[4] = LabelViewModel.Box5ProductLabel;
            }
            else
            {
                boxesSelected[4] = false;
            }
            if (LabelViewModel.Box6ProductLabel != null)
            {
                productLabels[5] = LabelViewModel.Box6ProductLabel;
            }
            else
            {
                boxesSelected[5] = false;
            }
            if (LabelViewModel.Box7ProductLabel != null)
            {
                productLabels[6] = LabelViewModel.Box7ProductLabel;
            }
            else
            {
                boxesSelected[6] = false;
            }
            if (LabelViewModel.Box8ProductLabel != null)
            {
                productLabels[7] = LabelViewModel.Box8ProductLabel;
            }
            else
            {
                boxesSelected[7] = false;
            }

            for (int i = 0; i < 8; i++)
            {
                boxesToPrint[i].IsSelected = boxesSelected[i];
                if (productLabels[i] != null)
                {
                    //boxesToPrint[i].LensInfo = _lensData.Get(productLabels[i]);
                    boxesToPrint[i].LensInfo = _lensData.Lenses.Include(m => m.Material).Where(l => l.ProductLabel == productLabels[i]).FirstOrDefault();
                }
                else
                {
                    boxesToPrint[i].LensInfo = null;
                }
            }

            if (boxesToPrint.Any(x => x.IsSelected))
            {

                string fileName = PdfGenerator.GenerateReport(boxesToPrint);
                return new PhysicalFileResult(Path.Combine(_env.ContentRootPath, fileName), "application/pdf");
            }
            else
            {
                return RedirectToPage("./Inventory");
            }
        }

        public IActionResult OnPostSaveToCSV()
        {
            return RedirectToPage("./Inventory");
        }

        [HttpGet]
        [Route("data.csv")]
        [Produces("text/csv")]
        public IActionResult OnPostAllInventory()
        {
            //List<Lens> csvData = new List<Lens>();
            //csvData = _lensData.Lenses.Include(m => m.Material).ToList();

            //return new OkObjectResult(csvData);

            //Works
            //PhysicalFileResult result = new PhysicalFileResult("C:\\Users\\dgreen\\Source\\Repos\\lens-inventory\\SeeMoreInventory\\wwwroot\\csv\\Test.csv", "text/csv");
            PhysicalFileResult result = new PhysicalFileResult(@"././csv/Test.csv", "text/csv");

            return result;

        }

    }
}