using System.Threading.Tasks;
using GetirBank.Database.Models;
using GetirBank.Dto;
using GetirBank.Helpers;

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
    }
}