using System.Threading.Tasks;
using GetirBank.Dto;

namespace GetirBank.Services
{
    public interface ITransactionService
    {
        public Task<TransactionResponse> WithDraw(TransactionRequest request, string customerId);
        public Task<TransactionResponse> Deposit(TransactionRequest request, string customerId);
        public Task<TransactionQueryResponse> GetTransactionsByDate(TransactionQueryRequest request, string customerId);
        public Task<TransactionQueryResponse> GetTransactionsByAccountId(string accountId, string customerId);
    }
}