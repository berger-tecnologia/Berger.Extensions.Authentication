using System.Security.Cryptography;

namespace Berger.Extensions.Jwt
{
    public static class SaltService
    {
        public static string Create()
        {
            byte[] random = new byte[128 / 8];

            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(random);

                return Convert.ToBase64String(random);
            }
        }
    }
}