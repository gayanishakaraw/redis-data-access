using RedisDataAccess.Interfaces;
using StackExchange.Redis;
using System;

namespace RedisDataAccess
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly Lazy<ConnectionMultiplexer> _connectionMultiplexer;

        public RedisConnectionFactory(string connectionString)
        {
            _connectionMultiplexer = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(connectionString));
        }

        /// <inheritdoc />
        public ConnectionMultiplexer Connection()
        {
            return _connectionMultiplexer.Value;
        }
    }
}
