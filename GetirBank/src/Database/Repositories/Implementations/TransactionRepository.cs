using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetirBank.Database.Models;
using GetirBank.Dto;
using GetirBank.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GetirBank.Database.Repositories.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankContext _bankContext;

        public TransactionRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public async Task<bool> PerformTransaction(TransactionRequest request)
        {
            try{
                _bankContext.Transaction.Add(new Transaction
                {
                    Id = Utils.GetTransactionId(),
                    AccountId = request.AccountId,
                    Amount = request.Balance,
                    TransactionType = request.TransactionType.ToString(),
                    CreatedAt = System.DateTime.Now
                });
                await _bankContext.SaveChangesAsync();
                return true;
            }
            catch (System.Exception){
                return false;
            }
        }

        public async Task<List<Transaction>> GetTransactions(TransactionQueryRequest request)
        {
            return await _bankContext.Transaction
                .Where(x => x.AccountId.Equals(request.AccountId) &&
                            (x.CreatedAt >= request.StartDate && x.CreatedAt <= request.EndDate))
                .ToListAsync();
        }
    }
}