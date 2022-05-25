using Parking_Lot.App.src.Exceptions;
using System.Collections.Generic;

namespace Parking_Lot.App.src.Models
{
    internal class Floor
    {
        internal int floorNumber { get; set; }
        internal IDictionary<int, Slot> slots { get; set; }

        public Floor(int floorNumber)
        {
            this.floorNumber = floorNumber;
            slots = new Dictionary<int, Slot>();
        }

        public Slot GetSlot(int slotNumber)
        {
            if (!slots.ContainsKey(slotNumber))
            {
                slots.Add(slotNumber, new Slot(slotNumber));
            }

            return slots[slotNumber];
        }

        public string ParkVehicle(Vehicle vehicle, int slotNumber)
        {
            string floorAndSlot = $"{floorNumber}";
            Slot slot = GetSlot(slotNumber);
            if(slot != null && slot.IsSlotAvailable(vehicle.vehicleType))
            {
                slot.ParkVehicle(vehicle);
                floorAndSlot += $"_{slot.slotNumber}";
            }               

            return floorAndSlot;
        }

        /// <summary>
        /// Unparks the vehicle from the occupied slot only if there is a vehicle parked
        /// </summary>
        /// <param name="slotNumber"></param>
        /// <returns>Instance of the parked vehicle</returns>
        public Vehicle UnParkVehicle(int slotNumber)
        {
            Vehicle vehicle = null;
            Slot slot = GetSlot(slotNumber);

            if (slot != null && slot.parkedVehicle != null)
            {
                vehicle = slot.UnparkVehicle();
            }
            else
            {
                throw new ParkingLotException("Invalid Ticket");
            }

            return vehicle;
        }
    }
}
