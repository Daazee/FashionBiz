using FashionBiz.Api.DTOs.Request;
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductCategory(long id)
        {
            var result = await _productCategoryRepository.GetItem(id);
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

        [HttpPatch]
        public async Task<IActionResult> PatchProductCategory(ProductCategoryUpdateRequestDTO requestDTO)
        {
            var result = await _productCategoryRepository.GetItem(requestDTO.ProductCategoryId);
            if (result != null)
            {
                result.ProductCategoryName = requestDTO.ProductCategoryName;
                result.ProductCategoryId = requestDTO.ProductCategoryId;
                result.Flag = "U";
                result.ModifiedBy = requestDTO.UserId;
                result.ModifiedOn = DateTime.Now;
                result = await _productCategoryRepository.UpdateItem(result);
            }

            return Ok(result);
        }
    }
}
