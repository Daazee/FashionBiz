using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionBiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {

        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductCategories()
        {
            var result = await _productCategoryRepository.GetItems();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostProductCategory(ProductCategory productCategory)
        {
            if (productCategory != null)
            {
                var result = await _productCategoryRepository.AddItem(productCategory);
                return Ok(result);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditProductCategory(ProductCategory productCategory)
        {

            var result = await _productCategoryRepository.UpdateItem(productCategory);
            return Ok(result);
        }
    }
}
