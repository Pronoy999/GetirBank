namespace GetirBank.Authentication
{
    public interface IAuthentication
    {
        public string GetToken(string id);
    }
}