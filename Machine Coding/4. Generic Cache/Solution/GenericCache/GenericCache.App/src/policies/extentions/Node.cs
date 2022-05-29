namespace GenericCache.App.src.policies.extentions
{
    internal class Node<K>
    {
        internal Node<K> previous;
        internal K? element;
        internal Node<K> next;

        public Node(K? key) => element = key;
    }
}
