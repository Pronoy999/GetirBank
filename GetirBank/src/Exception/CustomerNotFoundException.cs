using GetirBank.Helpers;

namespace GetirBank.Exception
{
    public class CustomerNotFoundException : System.Exception
    {
        public CustomerNotFoundException() : base(Constants.CustomerNotFound)
        {
        }
    }
}