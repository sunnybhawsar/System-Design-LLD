namespace GenericCache.App.src.exceptions
{
    internal class KeyNotFoundInStoreException : Exception
    {
        public KeyNotFoundInStoreException(string message = "Key not found.") : base(message)
        {
        }
    }
}
