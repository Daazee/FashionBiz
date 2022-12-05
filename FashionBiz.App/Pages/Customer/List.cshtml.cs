using FashionBiz.App.Utilities;
using FashionBiz.App.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FashionBiz.App.Pages.Customer
{
    public class ListModel : PageModel
    {
        IConfiguration Configuration;

        public IEnumerable<ListModel> CustomerListViewModels { get; set; }
        public ListModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public long CustomerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Sex { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public long CompanyId { get; set; }



        IEnumerable<CompanyListViewModel> companyListViewModels = new List<CompanyListViewModel>();
        public async Task OnGetAsync()
        {
            try
            {
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}/api/customer/";
                ApiRequest apiRequest = new ApiRequest(url);
                var response = await apiRequest.MakeHttpClientRequest(null, ApiRequest.Verbs.GET, null);

                if (Convert.ToInt16(response.StatusCode) == 200)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<DefaultApiResponse<IEnumerable<UserListViewModel>>>(responseString);
                    CustomerListViewModels = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ListModel>>(responseString);
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
    }
}
