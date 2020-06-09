using System.Threading.Tasks;

namespace RedisDataAccess.Interfaces
{
    public interface IRedisDataProvider<T>
    {
        /// <summary>
        /// Gets.
        /// </summary>
        /// <param name="key">The key.</param>
        Task<T> GetAsync(string key);

        /// <summary>
        /// Saves.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="record">The record.</param>
        Task SaveAsync(string key, T record);

        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        Task DeleteAsync(string key);
    }
}
