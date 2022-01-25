using System;
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
        private static TransactionQueryResponse FormatTransactionResponse(List<Transaction> listOfTrans)
        {
            foreach (var oneTransaction in listOfTrans){
                oneTransaction.Account.Transactions = null;
            }

            var response = new TransactionQueryResponse
            {
                Account = listOfTrans.FirstOrDefault()?.Account,
                Transactions = listOfTrans
            };
            foreach (var oneTransaction in response.Transactions){
                oneTransaction.Account = null;
            }

            return response;
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
                    CreatedAt = DateTime.Now
                });
                await _bankContext.SaveChangesAsync();
                return true;
            }
            catch (System.Exception){
                return false;
            }
        }

        public async Task<TransactionQueryResponse> GetTransactionsByDate(TransactionQueryRequest request)
        {
            var listOfTrans = await _bankContext.Transaction
                .Where(x => x.AccountId.Equals(request.AccountId) &&
                            (x.CreatedAt.Date >= request.StartDate.Date && x.CreatedAt.Date <= request.EndDate))
                .ToListAsync();
            return FormatTransactionResponse(listOfTrans);
        }

        public async Task<TransactionQueryResponse> GetTransactionsByAccount(string accountId)
        {
            var listOfTrans = await _bankContext.Transaction.Where(x => x.AccountId.Equals(accountId)).ToListAsync();
            return FormatTransactionResponse(listOfTrans);
        }
    }
}