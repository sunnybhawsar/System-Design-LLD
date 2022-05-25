using System;

namespace Parking_Lot.App.src.Exceptions
{
    internal class ServiceNotAvailableException : Exception
    {
        public ServiceNotAvailableException() : base("This service is not available right now, please try again later.")
        {
        }
    }
}
