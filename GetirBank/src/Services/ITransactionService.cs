using System.Collections.Generic;
using System.Threading.Tasks;
using GetirBank.Database.Models;
using GetirBank.Dto;

namespace GetirBank.Services
{
    public interface ITransactionService
    {
        public Task<TransactionResponse> WithDraw(TransactionRequest request);
        public Task<TransactionResponse> Deposit(TransactionRequest request);
        public Task<List<Transaction>> GetTransactions(TransactionQueryRequest request,string customerId);
    }
}