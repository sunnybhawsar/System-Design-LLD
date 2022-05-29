namespace GenericCache.App.src.policies
{
    internal class DateTimeEvictionPolicy<K> : IEvictionPolicy<K>
    {
        private static DateTimeEvictionPolicy<K> _instance;
        private IDictionary<K, DateTime> _track;

        /// <summary>
        /// Singleton
        /// </summary>
        private DateTimeEvictionPolicy()
        {
            _track = new Dictionary<K, DateTime>();
        }

        /// <summary>
        /// Returns singleton instance of LruEvictionPolicy
        /// </summary>
        public static DateTimeEvictionPolicy<K> Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DateTimeEvictionPolicy<K>();

                return _instance;
            }
        }

        /// <summary>
        /// Adds/Updates the time whenever a key is accessed
        /// </summary>
        /// <param name="key"></param>
        public void KeyAccessed(K key)
        {
            if (_track.ContainsKey(key))
                _track[key] = DateTime.UtcNow;
            else
                _track.Add(key, DateTime.UtcNow);
        }

        /// <summary>
        /// Get the best key to remove from store based on Least DateTime
        /// </summary>
        /// <returns></returns>
        public K? GetKeyToEvict()
        {
            K? bestKey;
            try
            {
                var orderedTrack = _track.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                bestKey = orderedTrack.Keys.FirstOrDefault();
                _track.Remove(bestKey);
            }
            catch(Exception e)
            {
                bestKey = default(K);
            }            

            return bestKey;
        }

        /// <summary>
        /// Resets the tracking dictionary
        /// </summary>
        public void Reset()
        {
            _track.Clear();
        }
    }
}
