using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FashionBiz.App.Pages.Customer
{
    public class NewMeasurementModel : PageModel
    {
        [BindProperty]
        public string GarmentType { get; set; }

        [BindProperty]
        public string Generalsize { get; set; } //large, medium, small

        [BindProperty]
        public string MeasurementType { get; set; }

        [BindProperty]
        public int Chest { get; set; }

        [BindProperty]
        public int Collar { get; set; }

        [BindProperty]
        public int Arm { get; set; }

        [BindProperty]
        public long Back { get; set; }

        [BindProperty]
        public int Waist { get; set; }

        [BindProperty]
        public long CustomerId { get; set; }
        public void OnGet()
        {
        }
    }
}
