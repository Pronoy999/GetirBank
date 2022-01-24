using System.Threading.Tasks;
using GetirBank.Dto;
using GetirBank.Exception;
using GetirBank.Helpers;
using GetirBank.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetirBank.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest request)
        {
            try{
                var userId = Utils.GetUserId(HttpContext?.User);
                if (string.IsNullOrEmpty(userId)){
                    return Unauthorized();
                }

                var response = await _accountService.CreateAccount(request, userId);
                return Ok(response);
            }
            catch (CustomerNotFoundException){
                return BadRequest(new BankApiException(new CustomerNotFoundException()));
            }
            catch (System.Exception){
                return Problem();
            }
        }

        [HttpGet("{accountId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetAccountByAccountId([FromRoute] string accountId)
        {
            try{
                if (accountId == null)
                    return BadRequest(new BankApiException(new AccountNotFoundException()));
                var userId = Utils.GetUserId(HttpContext?.User);
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized();
                var account = _accountService.GetAccountById(accountId);
                return Ok(account);
            }
            catch (AccountNotFoundException){
                return BadRequest(new BankApiException(new AccountNotFoundException()));
            }
        }
    }
}