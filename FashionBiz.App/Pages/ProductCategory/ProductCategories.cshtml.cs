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

        [BindProperty]
        public int ProductCategoryId { get; set; }

        [BindProperty]

        [Display(Name = "Product Category")]
        public string ProductCategoryName { get; set; }

        [BindProperty]
        public string Flag { get; set; }

        [BindProperty]
        public string CreatedBy { get; set; }

        [BindProperty]
        public string ModifiedBy { get; set; }

        [BindProperty]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
        public async Task OnGetAsync(int customerId)
        {
            try
            {
                ViewData["CustomerId"] = customerId;
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}/api/ProductCategory/";
                ApiRequest apiRequest = new ApiRequest();
                var response = await apiRequest.MakeHttpClientRequest(url, null, ApiRequest.Verbs.GET, null);

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

        public async Task<IActionResult> OnPostManageProductCategoryAsync([FromBody] ProductCategoryCreateModel productCategory)
        {
            try
            {
                ApiRequest apiRequest = new ApiRequest();
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}/api/productcategory/";
                ApiRequest.Verbs verb = ApiRequest.Verbs.PATCH;

                if (productCategory.ProductCategoryId == 0 && productCategory.Flag == "A")
                {
                    productCategory.CreatedBy = "admin";
                    productCategory.CreatedOn = DateTime.Now;
                    verb = ApiRequest.Verbs.POST;
                }
                else
                {
                    var response1 = await apiRequest.MakeHttpClientRequest(url, null, ApiRequest.Verbs.GET, null);
                
                }
                productCategory.ModifiedBy = "admin";
                productCategory.ModifiedOn = DateTime.Now;
                productCategory.CreatedBy = "admin";
                productCategory.CreatedOn = DateTime.Now;

                
                var response = await apiRequest.MakeHttpClientRequest(url, productCategory, verb, null);

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

        public async Task<JsonResult> OnGetRetrieveProductCategoryByIdAsync([FromQuery] long id)
        {
            ProductCategoriesModel result = new ProductCategoriesModel(Configuration);
            try
            {
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}/api/ProductCategory/{id}";
                ApiRequest apiRequest = new ApiRequest();
                var response = await apiRequest.MakeHttpClientRequest(url, null, ApiRequest.Verbs.GET, null);

                if (Convert.ToInt16(response.StatusCode) == 200)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductCategoriesModel>(responseString);
                    //ProductCategoryName = productCategory.ProductCategoryName;
                    //ProductCategoryId = productCategory.ProductCategoryId;
                }

            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
            return new JsonResult(result);
        }

    }
}
