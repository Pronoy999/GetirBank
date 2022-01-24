using System.Collections.Generic;
using System.Threading.Tasks;
using GetirBank.Database.Models;
using GetirBank.Dto;

namespace GetirBank.Database.Repositories
{
    public interface IAccountRepository
    {
        public Task<string> CreateAccount(CreateAccountRequest request, string customerId);
        public Account GetAccountById(string accountId);
        public Task<List<Account>> GetAccountByCustomerId(string customerId);
        public Task<bool> UpdateBalance(string accountId, double updatedBalance);
    }
}