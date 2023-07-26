namespace Berger.Extensions.Authentication
{
    public interface ISessionService
    {
        void Logoff();
        Guid GetSid();
        string GetIp();
        string GetName();
        Guid GetGroupSid();
        string GetEmail();
        List<string> GetRole();
    }
}