using System.Threading.Tasks;
using GetirBank.Dto;

namespace GetirBank.Services
{
    public interface IAuthService
    {
        public Task<LoginResponse> Login(LoginRequest request);
    }
}