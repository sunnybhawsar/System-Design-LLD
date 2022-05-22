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
            if(slot != null && slot.IsSlotAvailable(vehicle))
            {
                slot.ParkVehicle(vehicle);
                floorAndSlot += $"_{slot.slotNumber}";
            }               

            return floorAndSlot;
        }
    }
}
