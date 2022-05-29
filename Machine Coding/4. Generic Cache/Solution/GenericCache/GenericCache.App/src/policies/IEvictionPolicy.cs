namespace GenericCache.App.src.policies
{
    internal interface IEvictionPolicy<K>
    {
        /// <summary>
        /// Notifies the policy whenever key is fetched/added/updated
        /// </summary>
        /// <param name="key"></param>
        void KeyAccessed(K key);

        /// <summary>
        /// Get the best key that can be removed from the store based.
        /// </summary>
        /// <returns>Dynamic type of key</returns>
        K? GetKeyToEvict();

        /// <summary>
        /// Resets all the dependencies
        /// </summary>
        void Reset();
    }
}
