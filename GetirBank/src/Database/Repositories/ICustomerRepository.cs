using System.Threading.Tasks;
using GetirBank.Database.Models;
using GetirBank.Dto;

namespace GetirBank.Database.Repositories
{
    public interface ICustomerRepository
    {
        public Task<string> SaveCustomer(CreateCustomerDTO customerDto);
        public Customer GetCustomerById(string customerId);
    }
}