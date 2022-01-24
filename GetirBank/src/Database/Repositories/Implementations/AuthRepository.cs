using System.Linq;
using System.Threading.Tasks;
using GetirBank.Database.Models;
using GetirBank.Dto;
using GetirBank.Exception;
using Microsoft.EntityFrameworkCore;

namespace GetirBank.Database.Repositories.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BankContext _bankContext;

        public AuthRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public async Task<Customer> Login(LoginRequest request)
        {
            var custCredentials = await _bankContext.Credentials
                .Where(c => c.Email.Equals(request.EmailId) && c.Password.Equals(request.Password))
                .ToListAsync();
            if (!custCredentials.Any())
                throw new CustomerNotFoundException();
            return _bankContext.Customer.Single(c => c.EmailId.Equals(request.EmailId));
        }
    }
}