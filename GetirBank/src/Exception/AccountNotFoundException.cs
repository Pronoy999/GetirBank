using GetirBank.Helpers;

namespace GetirBank.Exception
{
    public class AccountNotFoundException : System.Exception
    {
        public AccountNotFoundException() : base(Constants.AccountNotFound)
        {
        }
    }
}