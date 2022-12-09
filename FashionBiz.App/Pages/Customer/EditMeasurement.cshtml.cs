using FashionBiz.App.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FashionBiz.App.Pages.Customer
{
    public class EditMeasurementModel : PageModel
    {

        IConfiguration Configuration;
        public EditMeasurementModel EditMeasurementPageModel { get; set; }
        public EditMeasurementModel(IConfiguration configuration)
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

        public async Task OnGetAsync(int customerId)
        {
            try
            {
                ViewData["CustomerId"] = customerId;
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}/api/customer/{customerId}";
                ApiRequest apiRequest = new ApiRequest(url);
                var response = await apiRequest.MakeHttpClientRequest(null, ApiRequest.Verbs.GET, null);

                if (Convert.ToInt16(response.StatusCode) == 200)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<DefaultApiResponse<IEnumerable<UserListViewModel>>>(responseString);
                    EditMeasurementPageModel = JsonConvert.DeserializeObject<EditMeasurementModel>(responseString);
                    CustomerId = EditMeasurementPageModel.CustomerId;
                    GarmentType = EditMeasurementPageModel?.GarmentType;
                    MeasurementType = EditMeasurementPageModel.MeasurementType;
                    Generalsize = EditMeasurementPageModel.Generalsize;
                    Collar = EditMeasurementPageModel.Collar;
                    Chest = EditMeasurementPageModel.Chest;
                    Arm = EditMeasurementPageModel.Arm;
                    Back = EditMeasurementPageModel.Back;
                    Waist = EditMeasurementPageModel.Waist;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
