namespace Berger.Extensions.Jwt
{
    public interface IAccountService
    {
        public void Logoff();
        public string Signin(string user, string password);
    }
}