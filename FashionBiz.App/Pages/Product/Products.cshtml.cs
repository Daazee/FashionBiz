using FashionBiz.App.CustomModel;
using FashionBiz.App.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FashionBiz.App.Pages.Product
{
    public class ProductsModel : PageModel
    {
        IConfiguration Configuration;
        public ProductsModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IEnumerable<ProductDetailCreateModel> Products { get; set; }
        public async Task OnGetAsync()
        {
            try
            {
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}/api/ProductCategory/";
                ApiRequest apiRequest = new ApiRequest();
                var response = await apiRequest.MakeHttpClientRequest(url, null, ApiRequest.Verbs.GET, null);

                if (Convert.ToInt16(response.StatusCode) == 200)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    var categories = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ProductCategoryCreateModel>>(responseString);
                    ViewData["ProductCategories"] = new SelectList(categories, "ProductCategoryId", "ProductCategoryName");
                }

                //Products
                string productUrl = $"{apiBaseUrl}/api/Product/";
                var productsResponse = await apiRequest.MakeHttpClientRequest(productUrl, null, ApiRequest.Verbs.GET, null);

                if (Convert.ToInt16(productsResponse.StatusCode) == 200)
                {
                    string responseString = await productsResponse.Content.ReadAsStringAsync();
                    Products = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ProductDetailCreateModel>>(responseString);
               
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> OnPostManageProductAsync([FromBody] ProductDetailCreateModel productDetail)
        {
            try
            {
                ApiRequest apiRequest = new ApiRequest();
                string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
                string url = $"{apiBaseUrl}/api/productdetail";
                ApiRequest.Verbs verb = ApiRequest.Verbs.PATCH;
                object request = null;
                if (productDetail.ProductDetailId == 0 && productDetail.Flag == "A")
                {
                    verb = ApiRequest.Verbs.POST;
                    request = new
                    {
                        ProductDetailId = productDetail.ProductDetailId,
                        ProductCategoryId = productDetail.ProductCategoryId,
                        ProductName = productDetail.ProductName,
                        Flag = "A",
                        CreatedBy = "admin",
                        ModifiedBy = "admin",
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now
                    };
                }
                else
                {
                    request = new
                    {
                        ProductDetailId = productDetail.ProductDetailId,
                        ProductCategoryId = productDetail.ProductCategoryId,
                        ProductName = productDetail.ProductName,
                        UserId = "admin"
                    };
                }
                var response = await apiRequest.MakeHttpClientRequest(url, request, verb, null);

                if (Convert.ToInt16(response.StatusCode) == 200)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    ViewData["Message"] = "Product Saved Successfully";
                }

            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return Page();
            }
            return RedirectToPage("/Product/Products");
        }

        //public async Task<JsonResult> OnGetRetrieveProductCategoryByIdAsync([FromQuery] long id)
        //{
        //    ProductCategoriesModel result = new ProductCategoriesModel(Configuration);
        //    try
        //    {
        //        string apiBaseUrl = Configuration.GetValue<string>("ApiBaseUrl");
        //        string url = $"{apiBaseUrl}/api/ProductCategory/{id}";
        //        ApiRequest apiRequest = new ApiRequest();
        //        var response = await apiRequest.MakeHttpClientRequest(url, null, ApiRequest.Verbs.GET, null);

        //        if (Convert.ToInt16(response.StatusCode) == 200)
        //        {
        //            string responseString = await response.Content.ReadAsStringAsync();
        //            result = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductCategoriesModel>(responseString);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ViewData["Message"] = ex.Message;
        //    }
        //    return new JsonResult(result);
        //}
    }
}
