using FashionBiz.App.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using FashionBiz.App.ViewModel;
using FashionBiz.App.CustomModel;

namespace FashionBiz.App.Pages.ProductCategory
{
    public class ProductCategoriesModel : PageModel
    {


        IConfiguration Configuration;

        public ProductCategoriesModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IEnumerable<ProductCategoriesModel> ProductCategories { get; set; }

        public int ProductCategoryId { get; set; }

        [Display(Name = "Product Category")]
        public string ProductCategoryName { get; set; }

        public string Flag { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
        public async Task OnGetAsync(int customerId)
        {
            try
            {
                ViewData["CustomerId"] = customerId;
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}/api/ProductCategory/";
                ApiRequest apiRequest = new ApiRequest(url);
                var response = await apiRequest.MakeHttpClientRequest(null, ApiRequest.Verbs.GET, null);

                if (Convert.ToInt16(response.StatusCode) == 200)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    ProductCategories = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ProductCategoriesModel>>(responseString);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> OnPostAddProductCategoryAsync([FromBody] ProductCategoryCreateModel productCategory)
        {
            try
            {
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}/api/productcategory/";


                productCategory.CreatedBy = "admin";
                productCategory.ModifiedBy = "admin";
                productCategory.CreatedOn = DateTime.Now;
                productCategory.ModifiedOn = DateTime.Now;

                ApiRequest apiRequest = new ApiRequest(url);
                var response = await apiRequest.MakeHttpClientRequest(productCategory, ApiRequest.Verbs.POST, null);

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
                return Page();
            }
            return RedirectToPage("/ProductCategory/ProductCategories");
        }
    }
}
