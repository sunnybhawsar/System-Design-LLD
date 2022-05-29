using GenericCache.App.src.policies.extentions;

namespace GenericCache.App.src.policies
{
    /// <summary>
    /// Least Recently Used
    /// </summary>
    internal class LruEvictionPolicy<K> : IEvictionPolicy<K>
    {
        private static LruEvictionPolicy<K> _instance;
        private DoublyLinkedList<K> _ddl;
        private IDictionary<K, Node<K>> _dic;

        /// <summary>
        /// Singleton
        /// </summary>
        private LruEvictionPolicy()
        {
            _ddl = new DoublyLinkedList<K>();
            _dic = new Dictionary<K, Node<K>>();
        }

        /// <summary>
        /// Returns singleton instance of LruEvictionPolicy
        /// </summary>
        public static LruEvictionPolicy<K> Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LruEvictionPolicy<K>();

                return _instance;
            }
        }

        /// <summary>
        /// Moves the node at the last of DDL
        /// </summary>
        /// <param name="key"></param>
        public void KeyAccessed(K key)
        {
            if (_dic.ContainsKey(key))
            {                
                _ddl.DetachNode(_dic[key]);
                _ddl.AddNodeAtLast(_dic[key]);
            }
            else
            {
                var node = _ddl.AddElementAtLast(key);
                _dic.Add(key, node);
            }
        }

        public K? GetKeyToEvict()
        {
            var node = _ddl.GetFirstNode();

            if (node != null && node.element != null)
            {
                _ddl.DetachNode(node);
                return node.element;
            }
            else
            {
                return default(K);
            }
        }

        /// <summary>
        /// Resets the tracking dictionary & doubly linked list
        /// </summary>
        public void Reset()
        {
            _dic.Clear();
            _ddl.Reset();
        }
    }
}
