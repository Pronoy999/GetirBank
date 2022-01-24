using System.Threading.Tasks;
using GetirBank.Dto;

namespace GetirBank.Database.Repositories
{
    public interface ITransactionRepository
    {
        public Task<bool> PerformTransaction(TransactionRequest request);
    }
}