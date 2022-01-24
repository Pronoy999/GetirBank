namespace GetirBank.Dto
{
    public class TransactionRequest
    {
        public string AccountId { get; set; }
        public TransactionTypes TransactionType { get; set; }
        public double Balance { get; set; }
    }
}