namespace Parking_Lot.App.src.Models
{
    internal class Slot
    {
        private int _slotNumber { get; set; }
        private Vehicle _parkedVehicle { get; set; }

        public Slot(int slotNumber)
        {
            _slotNumber = slotNumber;
        }

        public bool IsSlotAvailable()
        {
            return _parkedVehicle == null;
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            _parkedVehicle = vehicle;
        }

        public void UnparkVehicle()
        {
            _parkedVehicle = null;
        }
    }
}
