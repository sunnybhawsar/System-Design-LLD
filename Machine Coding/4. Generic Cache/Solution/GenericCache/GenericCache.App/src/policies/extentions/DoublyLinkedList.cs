using GenericCache.App.src.exceptions;

namespace GenericCache.App.src.policies.extentions
{
    internal class DoublyLinkedList<K>
    {
        Node<K> head;
        Node<K> tail;

        public DoublyLinkedList()
        {
            head = new Node<K>(default(K));
            tail = new Node<K>(default(K));

            head.next = tail;
            tail.previous = head;
        }

        /// <summary>
        /// Adds the node before tail
        /// </summary>
        /// <param name="node"></param>
        internal void AddNodeAtLast(Node<K> node)
        {
            tail.previous.next = node;
            node.next = tail;
            node.previous = tail.previous;
            tail.previous = node;
        }

        /// <summary>
        /// Initializes Node with provided element & adds at the last in the DDL
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Instance of recently added node</returns>
        internal Node<K> AddElementAtLast(K key)
        {
            var node = new Node<K>(key);

            AddNodeAtLast(node);

            return node;
        }

        /// <summary>
        /// Detachs any node at any position from DDL
        /// </summary>
        /// <param name="node"></param>
        internal void DetachNode(Node<K> node)
        {
            if (node != null)
            {
                node.previous.next = node.next;
                node.next.previous = node.previous;
            }
        }

        /// <summary>
        /// Gets 1st node from the front
        /// </summary>
        /// <returns>First node after head</returns>
        internal Node<K> GetFirstNode()
        {
            if (head.next != tail)
                return head.next;
            else
                throw new LinkedListException("Doubly linked list is empty!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="LinkedListException"></exception>
        internal Node<K> GetLastNode()
        {
            if (tail.previous != head)
                return tail.previous;
            else
                throw new LinkedListException("Doubly linked list is empty!");
        }

        /// <summary>
        /// Resets the doubly linked list
        /// </summary>
        internal void Reset()
        {
            head.next = tail;
            tail.previous = head;
        }
    }
}
