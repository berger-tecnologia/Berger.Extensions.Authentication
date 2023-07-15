using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Berger.Extensions.Authentication
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
        public static void SetLong(this ISession session, string key, long value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }
        public static long GetLong(this ISession session, string key)
        {
            var data = session.Get(key);

            return BitConverter.ToInt64(data, 0);
        }
    }
}