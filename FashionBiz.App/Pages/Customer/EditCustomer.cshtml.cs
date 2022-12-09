using FashionBiz.App.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FashionBiz.App.Pages.Customer
{
    public class EditCustomerModel : PageModel
    {
        IConfiguration Configuration;
        public EditCustomerModel EditCustomerPageModel { get; set; }
        public EditCustomerModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [BindProperty]
        public long CustomerId { get; set; }
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
        public string Gender { get; set; }
        public string[] Genders = new[] { "Male", "Female"};
    
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
                    EditCustomerPageModel = JsonConvert.DeserializeObject<EditCustomerModel>(responseString);
                    CustomerId = EditCustomerPageModel.CustomerId;
                    Firstname = EditCustomerPageModel?.Firstname;
                    Lastname = EditCustomerPageModel.Lastname;
                    PhoneNumber = EditCustomerPageModel.PhoneNumber;
                    EmailAddress = EditCustomerPageModel.EmailAddress;
                    AddressLine1 = EditCustomerPageModel.AddressLine1;
                    AddressLine2 = EditCustomerPageModel.AddressLine2;
                    Gender = EditCustomerPageModel.Gender;



                    //userLstModels = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ListModel>>(responseString);
                    //if (result.Object != null)
                    //{
                    //    statement = result.Object.ToList();
                    //    return statement;
                    //}
                    //else
                    //    return statement;
                }
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
                    CustomerId = CustomerId,
                    LastName = Lastname,
                    FirstName = Firstname,
                    AddressLine1 = AddressLine1,
                    AddressLine2 = AddressLine2,
                    Gender = Gender,
                    EmailAddress = EmailAddress,
                    PhoneNumber = PhoneNumber,
                    CompanyId = 0

                };

                ApiRequest apiRequest = new ApiRequest(url);
                var response = await apiRequest.MakeHttpClientRequest(customer, ApiRequest.Verbs.PUT, null);

                if (Convert.ToInt16(response.StatusCode) == 200)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    //userListViewModels = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<UserListViewModel>>(responseString);
                    ViewData["Message"] = "Customer Updated Successfully";
                }

            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }
    }
}
