using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionBiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            var result = await _stockRepository.GetItems();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostStock(Stock stock)
        {
            if (stock != null)
            {
                var result = await _stockRepository.AddItem(stock);
                return Ok(result);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditStock(Stock stock)
        {

            var result = await _stockRepository.UpdateItem(stock);
            return Ok(result);
        }
    }
}
