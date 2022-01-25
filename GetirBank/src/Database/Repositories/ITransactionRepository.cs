using System.Threading.Tasks;
using GetirBank.Dto;

namespace GetirBank.Database.Repositories
{
    public interface ITransactionRepository
    {
        public Task<bool> PerformTransaction(TransactionRequest request);
        public Task<TransactionQueryResponse> GetTransactionsByDate(TransactionQueryRequest request);
        public Task<TransactionQueryResponse> GetTransactionsByAccount(string accountId);
    }
}