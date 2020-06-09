using Newtonsoft.Json;
using RedisDataAccess.Interfaces;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace RedisDataAccess
{
    public class RedisDataProvider<T> : IRedisDataProvider<T>
    {
        internal readonly IDatabase _database;
        protected readonly IRedisConnectionFactory _redisConnectionFactory;

        public RedisDataProvider(IRedisConnectionFactory redisConnectionFactory)
        {
            _redisConnectionFactory = redisConnectionFactory;
            _database = _redisConnectionFactory.Connection().GetDatabase();
        }

        public async Task DeleteAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key) || key.Contains(":"))
            {
                throw new ArgumentException("invalid key!!");
            }

            await _database.HashDeleteAsync(typeof(T).Name, key);
        }

        public async Task<T> GetAsync(string key)
        {
            return JsonConvert.DeserializeObject<T>(await _database.HashGetAsync(typeof(T).Name, key));
        }

        public async Task SaveAsync(string key, T record)
        {
            await _database.HashSetAsync(record.GetType().Name, key, JsonConvert.SerializeObject(record));
        }
    }
}
