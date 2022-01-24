using System;
using System.Linq;
using System.Security.Claims;

namespace GetirBank.Helpers
{
    public class Utils
    {
        public static string GenerateCustomerId()
        {
            return "cust-" + Guid.NewGuid();
        }

        public static string GenerateAccountId()
        {
            return "acc-" + Guid.NewGuid();
        }

        public static string GetUserId(ClaimsPrincipal user)
        {
            return user?.Claims.First(c => c.Type == "id").Value;
        }

        public static string GetTransactionId()
        {
            return "trans-" + Guid.NewGuid();
        }
    }
}