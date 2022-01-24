using System.Threading.Tasks;
using GetirBank.Authentication;
using GetirBank.Database.Repositories;
using GetirBank.Dto;

namespace GetirBank.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IAuthentication _authentication;

        public AuthService(IAuthRepository authRepository, IAuthentication authentication)
        {
            _authRepository = authRepository;
            _authentication = authentication;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var customer = await _authRepository.Login(request);
            customer.Credentials = null;
            customer.Accounts = null;
            return new LoginResponse
            {
                Customer = customer,
                Token = _authentication.GetToken(customer.Id)
            };
        }
    }
}