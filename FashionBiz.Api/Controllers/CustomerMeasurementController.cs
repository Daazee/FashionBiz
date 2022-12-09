using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionBiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerMeasurementController : ControllerBase
    {

        private readonly ICustomerMeasurementRepository _customerMeasurementRepository;

        public CustomerMeasurementController(ICustomerMeasurementRepository customerMeasurementRepository)
        {
            _customerMeasurementRepository = customerMeasurementRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerMeasurements()
        {
            var result = await _customerMeasurementRepository.GetItems();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomerMeasurement(CustomerMeasurement customerMeasurement)
        {
            if (customerMeasurement != null)
            {
                var result = await _customerMeasurementRepository.AddItem(customerMeasurement);
                return Ok(result);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditCustomerMeasurement(CustomerMeasurement customerMeasurement)
        {

            var result = await _customerMeasurementRepository.UpdateItem(customerMeasurement);
            return Ok(result);
        }
    }
}
