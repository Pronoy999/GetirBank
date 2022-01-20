using System;
using System.Collections.Generic;

namespace GetirBank.Database.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string AccountType { get; set; }
        public double Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public Customer Customer { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}