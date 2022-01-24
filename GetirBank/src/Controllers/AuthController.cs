using System.Threading.Tasks;
using GetirBank.Dto;
using GetirBank.Exception;
using GetirBank.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetirBank.Controllers
{
    [ApiController]
    [Route("login")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try{
                var result = await _authService.Login(request);
                return Ok(result);
            }
            catch (CustomerNotFoundException){
                return BadRequest(new BankApiException(new CustomerNotFoundException()));
            }
        }
    }
}