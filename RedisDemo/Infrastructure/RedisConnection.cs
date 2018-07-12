#region

using System.Configuration;
using StackExchange.Redis;

#endregion

namespace RedisDemo.Infrastructure
{
    public sealed class RedisConnection
    {
        public readonly ConnectionMultiplexer Connection;

        static RedisConnection()
        {
        }

        private RedisConnection()
        {
            Connection =
                ConnectionMultiplexer.Connect(
                    ConfigurationManager.AppSettings["RedisCacheConnection"]);
        }

        public static RedisConnection Instance { get; } = new RedisConnection();
    }
}