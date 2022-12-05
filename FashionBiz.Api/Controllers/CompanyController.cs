using FashionBiz.Api.DTOs.Request;
using FashionBiz.Api.Models.Entities;
using FashionBiz.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionBiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpPost]
        //public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDTO requestDTO)
        public async Task<IActionResult> CreateCompany([FromBody] Company requestDTO)
        {
            var result = await _companyRepository.AddItem(requestDTO);
            return Ok(result);
        }
    }
}
