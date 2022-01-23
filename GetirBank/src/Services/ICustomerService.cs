using System.Threading.Tasks;
using GetirBank.Dto;

namespace GetirBank.Services
{
    public interface ICustomerService
    {
        public Task<string> CreateCustomer(CreateCustomerDTO request);
    }
}