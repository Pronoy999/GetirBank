using System.Threading.Tasks;
using GetirBank.Dto;

namespace GetirBank.Database.Repositories
{
    public interface IAccountRepository
    {
        public Task<string> CreateAccount(CreateAccountRequest request, string customerId);
    }
}