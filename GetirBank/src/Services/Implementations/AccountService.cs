using System.Threading.Tasks;
using GetirBank.Database.Repositories;
using GetirBank.Dto;

namespace GetirBank.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;

        public AccountService(IAccountRepository accountRepository, ICustomerRepository customerRepository)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
        }

        public async Task<CreateAccountResponse> CreateAccount(CreateAccountRequest request, string userId)
        {
            _customerRepository.GetCustomerById(userId);
            var accountId = await _accountRepository.CreateAccount(request, userId);
            return new CreateAccountResponse
            {
                AccountId = accountId,
                Balance = request.Balance
            };
        }
    }
}