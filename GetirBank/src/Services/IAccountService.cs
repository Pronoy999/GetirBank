using System.Collections.Generic;
using System.Threading.Tasks;
using GetirBank.Database.Models;
using GetirBank.Dto;

namespace GetirBank.Services
{
    public interface IAccountService
    {
        public Task<CreateAccountResponse> CreateAccount(CreateAccountRequest request, string userId);
        public Account GetAccountById(string accountId);
        public Task<List<Account>> GetAccountsByCustomerId(string customerId);
    }
}