using FashionBiz.App.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FashionBiz.App.Pages.Company
{
    public class EditCompanyModel : PageModel
    {
        IConfiguration Configuration;
        public EditCompanyModel EditCompanyPageModel { get; set; }

        public EditCompanyModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [BindProperty]
        public long CompanyId { get; set; }
        [BindProperty]
        public string? Code { get; set; }
        [BindProperty]
        public string? Name { get; set; }
        [BindProperty]
        public string? ShortName { get; set; }
        [BindProperty]
        public string? Address { get; set; }
        [BindProperty]
        public string? Phone1 { get; set; }
        [BindProperty]
        public string? Phone2 { get; set; }
        [BindProperty]
        public string? Email { get; set; }
        public async Task OnGet(long companyId)
        {
            try
            {
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}/api/company/{companyId}";
                ApiRequest apiRequest = new ApiRequest(url);
                var response = await apiRequest.MakeHttpClientRequest(null, ApiRequest.Verbs.GET, null);

                if (Convert.ToInt16(response.StatusCode) == 200)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<DefaultApiResponse<IEnumerable<UserListViewModel>>>(responseString);
                    EditCompanyPageModel = JsonConvert.DeserializeObject<EditCompanyModel>(responseString);
                    CompanyId = EditCompanyPageModel.CompanyId;
                    Name = EditCompanyPageModel?.Name;
                    ShortName = EditCompanyPageModel.ShortName;
                    Address = EditCompanyPageModel.Address;
                    Email = EditCompanyPageModel.Email;
                    Phone1 = EditCompanyPageModel.Phone1;
                    Phone2 = EditCompanyPageModel.Phone2;
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
                string url = $"{apiBaseUrl}/api/company/";

                object company = new
                {
                    CompanyId = CompanyId,
                    Name = Name,
                    ShortName = ShortName,
                    Address = Address,
                    Phone1 = Phone1,
                    Phone2 = Phone2,
                    Email = Email

                };

                ApiRequest apiRequest = new ApiRequest(url);
                var response = await apiRequest.MakeHttpClientRequest(company, ApiRequest.Verbs.PUT, null);

                if (Convert.ToInt16(response.StatusCode) == 200)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    ViewData["Message"] = "Company Updated Successfully";
                }

            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }
    }
}
