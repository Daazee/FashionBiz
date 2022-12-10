using FashionBiz.App.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FashionBiz.App.Pages.Company
{
    public class CompaniesModel : PageModel
    {
        IConfiguration Configuration;
        public CompaniesModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IEnumerable<CompaniesModel> companiesModel = null;

        public long CompanyId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public string? Address { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Email { get; set; }
        public string? CreatedBy { get; set; }
        public byte[]? Logo { get; set; }
        public string? Flag { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public async Task OnGetAsync()
        {
            try
            {
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}/api/company/";
                ApiRequest apiRequest = new ApiRequest(url);
                var response = await apiRequest.MakeHttpClientRequest(null, ApiRequest.Verbs.GET, null);

                if (Convert.ToInt16(response.StatusCode) == 200)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    companiesModel = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<CompaniesModel>>(responseString);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
