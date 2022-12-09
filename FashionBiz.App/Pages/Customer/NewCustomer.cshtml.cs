using FashionBiz.App.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Dynamic;

namespace FashionBiz.App.Pages.Customer
{
    public class NewCustomerModel : PageModel
    {
        IConfiguration Configuration;
        public NewCustomerModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [BindProperty]
        public string Firstname { get; set; }

        [BindProperty]
        public string Lastname { get; set; }

        [BindProperty]
        public string PhoneNumber { get; set; }

        [BindProperty]
        public string EmailAddress { get; set; }

        [BindProperty]
        public string AddressLine1 { get; set; }

        [BindProperty]
        public string AddressLine2 { get; set; }

        [BindProperty]
        public string Sex { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}/api/customer/";

                //if (Convert.ToInt16(response.StatusCode) == 200)
                //{
                //    string responseString = await response.Content.ReadAsStringAsync();
                //    //userListViewModels = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<UserListViewModel>>(responseString);

                //}
                return Page();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task OnPost()
        {
            try
            {
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}/api/customer/";

                object customer = new
                {
                    CustomerId = 0,
                    LastName = Lastname,
                    FirstName = Firstname,
                    AddressLine1 = AddressLine1,
                    AddressLine2 =AddressLine2,
                    Sex = Sex,
                    EmailAddress = EmailAddress,
                    PhoneNumber = PhoneNumber,
                    CompanyId = 0

                };

                ApiRequest apiRequest = new ApiRequest(url);
                var response = await apiRequest.MakeHttpClientRequest(customer, ApiRequest.Verbs.POST, null);

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

        public async void OnPostAddToCartAsync()
        {
            try
            {
                await Task.FromResult(10);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
