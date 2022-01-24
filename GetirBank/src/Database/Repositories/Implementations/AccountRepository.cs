using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetirBank.Database.Models;
using GetirBank.Dto;
using GetirBank.Exception;
using GetirBank.Helpers;
using Microsoft.EntityFrameworkCore;

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

        public Account GetAccountById(string accountId)
        {
            try{
                return _bankContext.Account.Single(a => a.Id.Equals(accountId));
            }
            catch (InvalidOperationException){
                throw new AccountNotFoundException();
            }
        }

        public async Task<List<Account>> GetAccountByCustomerId(string customerId)
        {
            return await _bankContext.Account.Where(a => a.CustomerId.Equals(customerId)).ToListAsync();
        }
    }
}