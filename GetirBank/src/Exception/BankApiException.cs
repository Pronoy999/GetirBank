namespace GetirBank.Exception
{
    public class BankApiException : System.Exception
    {
        public BankApiException(System.Exception? innerException) : base(innerException?.Message, innerException)
        {
        }
    }
}