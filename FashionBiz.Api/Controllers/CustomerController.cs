using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionBiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await _customerRepository.GetItems();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomer(long id)
        {
            var result = await _customerRepository.GetItem(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer(Customer customer)
        {
            if (customer != null)
            {
                var result = await _customerRepository.AddItem(customer);
                return Ok(result);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditCustomer(Customer customer)
        {

            var result = await _customerRepository.UpdateItem(customer);
            return Ok(result);
        }
    }
}
