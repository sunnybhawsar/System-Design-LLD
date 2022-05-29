namespace GenericCache.App.src.cache
{
    public interface ICache<K, V>
    {
        /// <summary>
        /// Adds/Updates data to the cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Put(K key, V value);

        /// <summary>
        /// Gets the value from the cache based on the key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Dynamic type of value</returns>
        V? Get(K key);

        /// <summary>
        /// Resets the cache & other dependencies
        /// </summary>
        void Purge();
    }
}
