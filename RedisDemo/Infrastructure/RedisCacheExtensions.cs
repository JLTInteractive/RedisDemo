#region

using Newtonsoft.Json;
using StackExchange.Redis;

#endregion

namespace RedisDemo.Infrastructure
{
    public static class RedisCacheExtensions
    {
        public static T Get<T>(this IDatabase cache, string key)
        {
            var value = cache.StringGet(key);

            return value.IsNull ? default(T) : JsonConvert.DeserializeObject<T>(cache.StringGet(key));
        }

        public static void Set(this IDatabase cache, string key, object value)
        {
            cache.StringSet(key, JsonConvert.SerializeObject(value));
        }
    }
}