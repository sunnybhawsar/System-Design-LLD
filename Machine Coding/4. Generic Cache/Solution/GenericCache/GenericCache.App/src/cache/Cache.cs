using GenericCache.App.src.exceptions;
using GenericCache.App.src.policies;
using GenericCache.App.src.stores;

namespace GenericCache.App.src.cache
{
    internal class Cache<K, V> : ICache<K, V>
    {
        private readonly IStore<K, V> _store;
        private readonly IEvictionPolicy<K> _evictionPolicy;

        public Cache(IStore<K, V> store, IEvictionPolicy<K> evictionPolicy)
        {
            _store = store;
            _evictionPolicy = evictionPolicy;
        }

        public V? Get(K key)
        {
            try
            {
                _evictionPolicy.KeyAccessed(key);
                return _store.GetValue(key);
            }
            catch (KeyNotFoundInStoreException e)
            {
                Console.WriteLine(e.Message);
                return default(V);
            }
        }        

        public void Put(K key, V value)
        {
            try
            {
                _store.PutValue(key, value);
                _evictionPolicy.KeyAccessed(key);
            }
            catch(StoreIsFullException e)
            {
                var removableKey = _evictionPolicy.GetKeyToEvict();
                if (removableKey == null)
                    throw new CacheException("Cache/Store not available.");

                _store.RemoveKey(removableKey);
                Put(key, value);
            }
        }

        public void Purge()
        {            
            _evictionPolicy.Reset();
            _store.Purge();
        }
    }
}
