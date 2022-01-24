using System;
using System.Linq;
using System.Threading.Tasks;
using GetirBank.Database.Models;
using GetirBank.Dto;
using GetirBank.Exception;
using GetirBank.Helpers;

namespace GetirBank.Database.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BankContext _bankContext;

        public CustomerRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public async Task<string> SaveCustomer(CreateCustomerDTO customerDto)
        {
            Customer customer;
            try{
                customer = GetCustomerByEmail(customerDto.EmailId);
            }
            catch (CustomerNotFoundException){
                customer = null;
            }

            if (customer == null){
                customer = new Customer
                {
                    Id = Utils.GenerateCustomerId(),
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    EmailId = customerDto.EmailId,
                    PhoneNumber = customerDto.PhoneNumber,
                    CreatedAt = DateTime.Now
                };
            }
            else{
                throw new CustomerAlreadyRegisteredException();
            }

            var credentials = new Credentials
            {
                Email = customerDto.EmailId,
                Password = customerDto.Password,
                IsActive = true,
                CreatedAt = DateTime.Now
            };
            _bankContext.Add(customer);
            _bankContext.Add(credentials);
            await _bankContext.SaveChangesAsync();
            return customer.Id;
        }

        public Customer GetCustomerById(string customerId)
        {
            try{
                return _bankContext.Customer.Single(c => c.Id.Equals(customerId.ToLower()));
            }
            catch (InvalidOperationException){
                throw new CustomerNotFoundException();
            }
        }

        public Customer GetCustomerByEmail(string emailId)
        {
            try{
                var value = _bankContext.Customer.Single(c => c.EmailId.Equals(emailId.ToLower()));
                return value;
            }
            catch (InvalidOperationException){
                throw new CustomerNotFoundException();
            }
        }
    }
}