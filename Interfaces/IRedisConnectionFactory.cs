using StackExchange.Redis;

namespace RedisDataAccess.Interfaces
{
    public interface IRedisConnectionFactory
    {
        /// <summary>
        /// Connections this instance.
        /// </summary>
        /// <returns></returns>
        ConnectionMultiplexer Connection();
    }
}
