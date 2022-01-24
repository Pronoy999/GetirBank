using GetirBank.Helpers;

namespace GetirBank.Exception
{
    public class InsufficientBalanceException : System.Exception
    {
        public InsufficientBalanceException() : base(Constants.InsufficientBalance)
        {
        }
    }
}