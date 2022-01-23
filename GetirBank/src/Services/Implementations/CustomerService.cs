using System.Threading.Tasks;
using GetirBank.Database.Repositories;
using GetirBank.Dto;

namespace GetirBank.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<string> CreateCustomer(CreateCustomerDTO request)
        {
            return await _customerRepository.SaveCustomer(request);
        }
    }
}