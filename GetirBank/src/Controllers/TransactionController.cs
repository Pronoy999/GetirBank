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
    [Route("transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> PerformTransaction([FromBody] TransactionRequest request)
        {
            try{
                var customerId = Utils.GetUserId(HttpContext?.User);
                if (string.IsNullOrEmpty(customerId))
                    return Unauthorized();
                return request.TransactionType switch
                {
                    TransactionTypes.Credit => Ok(await _transactionService.Deposit(request, customerId)),
                    TransactionTypes.Debit => Ok(await _transactionService.WithDraw(request, customerId)),
                    _ => BadRequest()
                };
            }
            catch (AccountNotFoundException){
                return BadRequest(new BankApiException(new AccountNotFoundException()));
            }
            catch (InsufficientBalanceException){
                return BadRequest(new BankApiException(new InsufficientBalanceException()));
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetTransactionsByDate([FromQuery] TransactionQueryRequest request)
        {
            try{
                var customerId = Utils.GetUserId(HttpContext?.User);
                if (string.IsNullOrEmpty(customerId))
                    return Unauthorized();
                return Ok(await _transactionService.GetTransactionsByDate(request, customerId));
            }
            catch (AccountNotFoundException){
                return BadRequest(new BankApiException(new AccountNotFoundException()));
            }
        }

        [HttpGet("{accountId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetTransactionsByAccountId([FromRoute] string accountId)
        {
            try{
                var customerId = Utils.GetUserId(HttpContext?.User);
                if (string.IsNullOrEmpty(customerId))
                    return Unauthorized();
                return Ok(await _transactionService.GetTransactionsByAccountId(accountId, customerId));
            }
            catch (AccountNotFoundException){
                return BadRequest(new BankApiException(new AccountNotFoundException()));
            }
        }
    }
}