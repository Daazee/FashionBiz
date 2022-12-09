using FashionBiz.App.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FashionBiz.App.Pages.Customer
{
    public class NewMeasurementModel : PageModel
    {
        IConfiguration Configuration;
        public NewMeasurementModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

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

        public async Task OnPost()
        {
            try
            {
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}http://localhost:5029/api/customer/";

                object customerMeasurement = new
                {
                    CustomerId = CustomerId,
                    GarmentType = GarmentType,
                    Generalsize = Generalsize,
                    MeasurementType = MeasurementType,
                    Chest = Chest,
                    Collar = Collar,
                    Arm = Arm,
                    Back = Back,
                    Waist = Waist

                };

                ApiRequest apiRequest = new ApiRequest(url);
                var response = await apiRequest.MakeHttpClientRequest(customerMeasurement, ApiRequest.Verbs.POST, null);

                if (Convert.ToInt16(response.StatusCode) == 200)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    //userListViewModels = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<UserListViewModel>>(responseString);
                    ViewData["Message"] = "Customer Created Successfully";
                }

            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }

    }
}
