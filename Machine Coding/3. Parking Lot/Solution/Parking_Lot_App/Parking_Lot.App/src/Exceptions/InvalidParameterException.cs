using System;

namespace Parking_Lot.App.src.Exceptions
{
    internal class InvalidParameterException : Exception
    {
        public InvalidParameterException() : base("Invalid parameters passed for the valid command.")
        {
        }
    }
}
