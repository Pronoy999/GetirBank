using System;

namespace GetirBank.Dto
{
    public class TransactionQueryRequest
    {
        public string AccountId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}