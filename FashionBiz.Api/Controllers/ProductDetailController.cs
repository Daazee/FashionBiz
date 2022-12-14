using FashionBiz.Api.DTOs.Request;
using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionBiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {

        private readonly IProductDetailRepository _productDetailRepository;

        public ProductDetailController(IProductDetailRepository productDetailRepository)
        {
            _productDetailRepository = productDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductDetails()
        {
            var result = await _productDetailRepository.GetItems();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostProductDetail(ProductDetail productDetail)
        {
            if (productDetail != null)
            {
                var result = await _productDetailRepository.AddItem(productDetail);
                return Ok(result);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditProductDetail(ProductDetail productDetail)
        {

            var result = await _productDetailRepository.UpdateItem(productDetail);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchProduct(ProductUpdateRequestDTO requestDTO)
        {
            var result = await _productDetailRepository.GetItem(requestDTO.ProductDetailId);
            if (result != null)
            {
                result.ProductName = requestDTO.ProductName;
                result.ProductCategoryId = requestDTO.ProductCategoryId;
                result.Flag = "U";
                result.ModifiedBy = requestDTO.UserId;
                result.ModifiedOn = DateTime.Now;
                result = await _productDetailRepository.UpdateItem(result);
            }

            return Ok(result);
        }
    }
}
