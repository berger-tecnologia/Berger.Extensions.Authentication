namespace Berger.Extensions.Authentication
{
    public interface IAccountService
    {
        public void Logoff();
        public string Signin(string user, string password);
    }
}