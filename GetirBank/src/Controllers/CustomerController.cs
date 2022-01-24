using System.Threading.Tasks;
using GetirBank.Dto;
using GetirBank.Exception;
using GetirBank.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetirBank.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDTO request)
        {
            try{
                var response = await _customerService.CreateCustomer(request);
                return Ok(response);
            }
            catch (CustomerAlreadyRegisteredException e){
                return BadRequest(new BankApiException(e));
            }
        }
    }
}