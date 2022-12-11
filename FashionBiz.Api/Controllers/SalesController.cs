using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionBiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {

        private readonly ISalesRepository _salesRepository;

        public SalesController(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSales()
        {
            var result = await _salesRepository.GetItems();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostSales(Sales sales)
        {
            if (sales != null)
            {
                var result = await _salesRepository.AddItem(sales);
                return Ok(result);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditSales(Sales sales)
        {

            var result = await _salesRepository.UpdateItem(sales);
            return Ok(result);
        }
    }
}
