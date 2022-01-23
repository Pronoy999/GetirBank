using System.Threading.Tasks;
using GetirBank.Dto;

namespace GetirBank.Database.Repositories
{
    public interface ICustomerRepository
    {
        public Task<string> SaveCustomer(CreateCustomerDTO customerDto);
    }
}