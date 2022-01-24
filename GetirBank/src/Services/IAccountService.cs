using System.Threading.Tasks;
using GetirBank.Dto;

namespace GetirBank.Services
{
    public interface IAccountService
    {
        public Task<CreateAccountResponse> CreateAccount(CreateAccountRequest request, string userId);
    }
}