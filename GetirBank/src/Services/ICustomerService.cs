using System.Threading.Tasks;
using GetirBank.Dto;

namespace GetirBank.Services
{
    public interface ICustomerService
    {
        public Task<CustomerCreateResponse> CreateCustomer(CreateCustomerDTO request);
    }
}