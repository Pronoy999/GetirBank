using System.Threading.Tasks;
using GetirBank.Database.Models;
using GetirBank.Dto;

namespace GetirBank.Database.Repositories
{
    public interface IAuthRepository
    {
        public Task<Customer> Login(LoginRequest request);
    }
}