using Parking_Lot.App.src.Enums;

namespace Parking_Lot.App.src.Models
{   

    internal class Vehicle
    {
        internal VehicleType vehicleType { get; set; }
        internal string registrationNumber { get; set; }
        internal Color color { get; set; }

        public Vehicle()
        {

        }
    }
}
