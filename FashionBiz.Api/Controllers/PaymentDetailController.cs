using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionBiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {

        private readonly IPaymentDetailRepository _paymentDetailRepository;

        public PaymentDetailController(IPaymentDetailRepository paymentDetailRepository)
        {
            _paymentDetailRepository = paymentDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentDetails()
        {
            var result = await _paymentDetailRepository.GetItems();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostPaymentDetails(PaymentDetail paymentDetail)
        {
            if (paymentDetail != null)
            {
                var result = await _paymentDetailRepository.AddItem(paymentDetail);
                return Ok(result);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditPaymentDetails(PaymentDetail paymentDetails)
        {

            var result = await _paymentDetailRepository.UpdateItem(paymentDetails);
            return Ok(result);
        }
    }
}
