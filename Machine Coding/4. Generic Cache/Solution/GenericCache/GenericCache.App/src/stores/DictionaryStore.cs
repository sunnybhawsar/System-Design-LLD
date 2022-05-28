using GenericCache.App.src.exceptions;

namespace GenericCache.App.src.stores
{
    internal class DictionaryStore<K, V> : IStore<K, V>
    {
        private static DictionaryStore<K, V> _instance;
        private IDictionary<K, V> _store;
        private const int _storeLimit = 5;

        /// <summary>
        /// Singleton
        /// </summary>
        private DictionaryStore()
        {
            _store = new Dictionary<K, V>(_storeLimit);
        }

        /// <summary>
        /// Get singleton instance of DictionaryStore
        /// </summary>
        public static DictionaryStore<K, V> Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DictionaryStore<K, V>();

                return _instance;
            }
        }

        public V GetValue(K key)
        {
            if (_store.ContainsKey(key))
                return _store[key];

            throw new KeyNotFoundInStoreException();
        }

        public void PutValue(K key, V value)
        {
            if (_store.ContainsKey(key))
                _store[key] = value;
            else if (_store.Count <= _storeLimit)
                _store.Add(key, value);
            else
                throw new StoreIsFullException();

        }

        public void RemoveKey(K key)
        {
            if (_store.ContainsKey(key))
                _store.Remove(key);
            else
                throw new KeyNotFoundInStoreException();
        }
    }
}
