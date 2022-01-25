using System;

namespace GetirBank.Database.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public Account Account { get; set; }
        public string TransactionType { get; set; }
        public double Amount { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public string AccountId { get; set; }
    }
}