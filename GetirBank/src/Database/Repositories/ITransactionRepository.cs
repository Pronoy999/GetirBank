using System.Collections.Generic;
using System.Threading.Tasks;
using GetirBank.Database.Models;
using GetirBank.Dto;

namespace GetirBank.Database.Repositories
{
    public interface ITransactionRepository
    {
        public Task<bool> PerformTransaction(TransactionRequest request);
        public Task<List<Transaction>> GetTransactions(TransactionQueryRequest request);
    }
}