using FashionBiz.App.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FashionBiz.App.Pages.Customer
{
    public class MyMeasurementsModel : PageModel
    {
        IConfiguration Configuration;

        public MyMeasurementsModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public long MeasurementId { get; set; }

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

        public IEnumerable<MyMeasurementsModel> MyMeasurements { get; set; }
        public async Task OnGetAsync(int customerId)
        {
            try
            {
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}/api/Customer/{customerId}/CustomerMeasurement/";
                ApiRequest apiRequest = new ApiRequest(url);
                var response = await apiRequest.MakeHttpClientRequest(null, ApiRequest.Verbs.GET, null);

                if (Convert.ToInt16(response.StatusCode) == 200)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    MyMeasurements = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<MyMeasurementsModel>>(responseString);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
