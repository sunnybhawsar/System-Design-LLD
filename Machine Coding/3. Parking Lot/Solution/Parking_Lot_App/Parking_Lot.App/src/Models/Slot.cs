using Parking_Lot.App.src.Enums;

namespace Parking_Lot.App.src.Models
{
    internal class Slot
    {
        internal int slotNumber { get; private set; }
        internal VehicleType slotType { get; private set; }
        internal Vehicle parkedVehicle { get; private set; }

        public Slot(int slotNumber)
        {
            this.slotNumber = slotNumber;

            if (slotNumber == 1)
                slotType = VehicleType.TRUCK;
            else if (slotNumber == 2 || slotNumber == 3)
                slotType = VehicleType.BIKE;
            else if (slotNumber >= 4)
                slotType = VehicleType.CAR;
        }

        public bool IsSlotAvailable(Vehicle vehicle)
        {
            if (vehicle.vehicleType == slotType && parkedVehicle == null)
            {
                return true;
            }

            return false;
        }

        public int ParkVehicle(Vehicle vehicle)
        {
            parkedVehicle = vehicle;
            return slotNumber;
        }

        public void UnparkVehicle()
        {
            parkedVehicle = null;
        }
    }
}
