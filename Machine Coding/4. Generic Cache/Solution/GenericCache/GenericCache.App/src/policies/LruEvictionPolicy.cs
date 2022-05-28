namespace GenericCache.App.src.policies
{
    /// <summary>
    /// Least Recently Used
    /// </summary>
    internal class LruEvictionPolicy<K> : IEvictionPolicy<K>
    {
        public K? GetKeyToEvict()
        {
            throw new NotImplementedException();
        }

        public void KeyAccessed(K key)
        {
            throw new NotImplementedException();
        }
    }
}
