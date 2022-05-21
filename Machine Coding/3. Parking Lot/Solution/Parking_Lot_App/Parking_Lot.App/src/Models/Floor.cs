using System.Collections.Generic;

namespace Parking_Lot.App.src.Models
{
    internal class Floor
    {
        private int _floorNumber { get; set; }
        private IDictionary<int, Slot> _slots { get; set; }

        public Floor(int floorNumber)
        {
            _floorNumber = floorNumber;
            _slots = new Dictionary<int, Slot>();
        }

        public Slot GetSlot(int slotNumber)
        {
            if (!_slots.ContainsKey(slotNumber))
            {
                _slots.Add(slotNumber, new Slot(slotNumber));
            }

            return _slots[slotNumber];
        }
    }
}
