using GenericCache.App.src.enums;
using GenericCache.App.src.policies;
using GenericCache.App.src.stores;

namespace GenericCache.App.src.cache
{
    public class CacheFactory<K, V>
    {
        private IStore<K, V> _store;
        private IEvictionPolicy<K> _evictionPolicy;

        public CacheFactory(StorageType storageType, EvictionPolicyType policyType, int cacheCapacity)
        {
            switch (storageType)
            {
                default:
                case StorageType.DICTIONARY:
                    _store = DictionaryStore<K, V>.Instance(cacheCapacity);
                    break;
            }

            switch (policyType)
            {                
                case EvictionPolicyType.DATETIME:
                    _evictionPolicy = DateTimeEvictionPolicy<K>.Instance;
                    break;

                default:
                case EvictionPolicyType.LRU:
                    _evictionPolicy = LruEvictionPolicy<K>.Instance;
                    break;
            }   
        }

        /// <summary>
        /// Gets cache based on the choice
        /// </summary>
        /// <returns>Instance of ICache</returns>
        public ICache<K, V> GetCache()
        {
            ICache<K, V> cache = new Cache<K, V>(_store, _evictionPolicy);
            return cache;
        }
    }
}
