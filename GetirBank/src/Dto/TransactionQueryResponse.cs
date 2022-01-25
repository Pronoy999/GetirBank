using System.Collections.Generic;
using GetirBank.Database.Models;

namespace GetirBank.Dto
{
    public class TransactionQueryResponse
    {
        public Account Account { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}