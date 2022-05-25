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

        /// <summary>
        /// Gets the floor from the dictionary, adds the floor to the dictionary if absent
        /// </summary>
        /// <param name="floorNumber"></param>
        /// <returns>Instance of the Floor</returns>
        public Floor GetFloor(int floorNumber)
        {
            if (!floors.ContainsKey(floorNumber))
            {
                floors.Add(floorNumber, new Floor(floorNumber));
            }

            return floors[floorNumber];
        }

        /// <summary>
        /// Parks the specific vehicle to the specific available slot
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="floorNumber"></param>
        /// <param name="slotNumber"></param>
        /// <returns>Ticket Id</returns>
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

        public Vehicle UnparkVehicle(int floorNumber, int slotNumber)
        {
            Floor floor = GetFloor(floorNumber);
            return floor?.UnParkVehicle(slotNumber) ?? null;
        }
    }
}
