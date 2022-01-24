using System.Threading.Tasks;
using GetirBank.Authentication;
using GetirBank.Database.Repositories;
using GetirBank.Dto;

namespace GetirBank.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAuthentication _authentication;

        public CustomerService(ICustomerRepository customerRepository, IAuthentication authentication)
        {
            _customerRepository = customerRepository;
            _authentication = authentication;
        }

        public async Task<CustomerCreateResponse> CreateCustomer(CreateCustomerDTO request)
        {
            var customerId = await _customerRepository.SaveCustomer(request);
            return new CustomerCreateResponse
            {
                CustomerId = customerId,
                Token = _authentication.GetToken(customerId)
            };
        }
    }
}