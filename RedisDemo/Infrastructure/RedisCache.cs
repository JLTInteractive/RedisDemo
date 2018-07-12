#region

using System.Linq;
using StackExchange.Redis;

#endregion

namespace RedisDemo.Infrastructure
{
    public class RedisCache
    {
        private readonly IDatabase _cache;

        public RedisCache()
        {
            _cache = RedisConnection.Instance.Connection.GetDatabase();
        }

        public T Get<T>(string key)
        {
            var data = _cache.Get<T>(key);

            return data;
        }

        public void Put(string key, object value)
        {
            _cache.Set(key, value);
        }

        public void Clear()
        {
            var connection = RedisConnection.Instance.Connection;
            var endpoints = connection.GetEndPoints(true);

            foreach (var server in endpoints.Select(endpoint => connection.GetServer(endpoint)))
            {
                server.FlushAllDatabases();
            }
        }
    }
}