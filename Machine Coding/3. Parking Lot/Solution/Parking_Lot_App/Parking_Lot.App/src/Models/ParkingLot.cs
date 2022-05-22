using System.Collections.Generic;

namespace Parking_Lot.App.src.Models
{
    internal class ParkingLot
    {
        internal string id { get; private set; }
        internal  int totalFloors { get; private set; }
        internal  int totalSlotsPerFloor { get; private set; }
        internal IDictionary<int, Floor> floors { get; private set; }

        public ParkingLot(string id, int totalFloors, int totalSlotsPerFloor)
        {            
            this.id = id;
            this.totalFloors = totalFloors;
            this.totalSlotsPerFloor = totalSlotsPerFloor;

            this.floors = new Dictionary<int, Floor>(this.totalFloors);
        }

        public Floor GetFloor(int floorNumber)
        {
            if (!floors.ContainsKey(floorNumber))
            {
                floors.Add(floorNumber, new Floor(floorNumber));
            }

            return floors[floorNumber];
        }

        public string ParkVehicle(Vehicle vehicle, int floorNumber, int slotNumber)
        {
            string ticketId = $"{id}";
            Floor floor = GetFloor(floorNumber);
            if (floor != null)
            {
                string floorAndSlot = floor.ParkVehicle(vehicle, slotNumber);
                ticketId += $"_{floorAndSlot}";
            }

            return ticketId;
        }
    }
}
