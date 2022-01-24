using System.Threading.Tasks;
using GetirBank.Database.Repositories;
using GetirBank.Dto;
using GetirBank.Exception;

namespace GetirBank.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public TransactionService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionResponse> WithDraw(TransactionRequest request)
        {
            var response = new TransactionResponse
            {
                IsSuccess = false
            };
            var currentBalance = _accountRepository.GetAccountById(request.AccountId).Balance;
            if (request.Balance > currentBalance)
                throw new InsufficientBalanceException();
            var newBalance = currentBalance - request.Balance;
            var isSuccessTransaction = await _transactionRepository.PerformTransaction(request);
            if (!isSuccessTransaction)
                return response;

            var isBalanceUpdated = await _accountRepository.UpdateBalance(request.AccountId, newBalance);
            if (isBalanceUpdated)
                response.IsSuccess = true;
            return response;
        }

        public async Task<TransactionResponse> Deposit(TransactionRequest request)
        {
            var response = new TransactionResponse
            {
                IsSuccess = false
            };
            var currentBalance = _accountRepository.GetAccountById(request.AccountId).Balance;
            var newBalance = currentBalance + request.Balance;
            var isSuccessTransaction = await _transactionRepository.PerformTransaction(request);
            if (!isSuccessTransaction)
                return response;
            var isBalanceUpdated = await _accountRepository.UpdateBalance(request.AccountId, newBalance);
            if (isBalanceUpdated)
                response.IsSuccess = true;
            return response;
        }
    }
}