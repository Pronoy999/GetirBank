using System.Threading.Tasks;
using GetirBank.Database.Models;
using GetirBank.Dto;
using GetirBank.Helpers;

namespace GetirBank.Database.Repositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankContext _bankContext;

        public AccountRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public async Task<string> CreateAccount(CreateAccountRequest request, string customerId)
        {
            var account = new Account
            {
                Id = Utils.GenerateAccountId(),
                AccountType = request.AccountType,
                Balance = request.Balance,
                CustomerId = customerId
            };
            _bankContext.Account.Add(account);
            await _bankContext.SaveChangesAsync();
            return account.Id;
        }
    }
}