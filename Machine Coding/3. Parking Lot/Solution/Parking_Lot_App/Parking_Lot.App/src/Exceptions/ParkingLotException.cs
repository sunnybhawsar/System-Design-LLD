using System;

namespace Parking_Lot.App.src.Exceptions
{
    internal class ParkingLotException : Exception
    {
        public ParkingLotException(string message) : base(message)
        {
        }
    }
}
