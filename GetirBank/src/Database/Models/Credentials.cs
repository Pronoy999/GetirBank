using System;

namespace GetirBank.Database.Models
{
    public class Credentials
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public Customer Customer { get; set; }
    }
}