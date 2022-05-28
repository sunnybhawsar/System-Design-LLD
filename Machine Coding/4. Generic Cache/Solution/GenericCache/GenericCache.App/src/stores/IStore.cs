namespace GenericCache.App.src.stores
{
    internal interface IStore<K, V>
    {
        /// <summary>
        /// Adds/Updates the value to the store
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void PutValue(K key, V value);

        /// <summary>
        /// Returns the value from the store based on the key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Dynamic type of value</returns>
        V GetValue(K key);

        /// <summary>
        /// Removes the desired key from the store based on the eviction policy
        /// </summary>
        /// <param name="key"></param>
        void RemoveKey(K key);
    }
}
