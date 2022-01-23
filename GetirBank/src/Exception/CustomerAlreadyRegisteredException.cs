using GetirBank.Helpers;

namespace GetirBank.Exception
{
    public class CustomerAlreadyRegisteredException:System.Exception
    {
        public CustomerAlreadyRegisteredException() : base(Constants.CustomerAlreadyRegistered)
        {
        }
    }
}