namespace GenericCache.App.src.exceptions
{
    internal class StoreIsFullException : Exception
    {
        public StoreIsFullException(string message = "Store is full.") : base(message)
        {
        }
    }
}
