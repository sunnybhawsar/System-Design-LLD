using Parking_Lot.App.src.Enums;

namespace Parking_Lot.App.src.Models
{   

    internal class Vehicle
    {
        internal VehicleType vehicleType { get; private set; }
        internal string registrationNumber { get; private set; }
        internal Color color { get; private set; }

        public Vehicle(VehicleType vehicleType, string registrationNumber, Color color)
        {
            this.vehicleType = vehicleType;
            this.registrationNumber = registrationNumber;
            this.color = color;
        }
    }
}
