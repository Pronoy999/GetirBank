using GetirBank.Database.Models;

namespace GetirBank.Dto
{
    public class LoginResponse
    {
        public Customer Customer { get; set; }
        public string Token { get; set; }
    }
}