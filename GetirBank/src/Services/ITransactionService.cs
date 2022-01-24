using System.Threading.Tasks;
using GetirBank.Dto;

namespace GetirBank.Services
{
    public interface ITransactionService
    {
        public Task<TransactionResponse> WithDraw(TransactionRequest request);
        public Task<TransactionResponse> Deposit(TransactionRequest request);
    }
}