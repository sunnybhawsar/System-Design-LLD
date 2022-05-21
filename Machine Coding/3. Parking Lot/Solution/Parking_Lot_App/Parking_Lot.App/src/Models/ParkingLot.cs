using System.Collections.Generic;

namespace Parking_Lot.App.src.Models
{
    internal class ParkingLot
    {
        private string _id { get; set; }
        private int _totalFloors { get; set; }
        private int _totalSlotsPerFloor { get; set; }
        private IDictionary<int, Floor> _floors { get; set; }

        public ParkingLot(string id, int totalFloors, int totalSlotsPerFloor)
        {            
            _id = id;
            _totalFloors = totalFloors;
            _totalSlotsPerFloor = totalSlotsPerFloor;

            _floors = new Dictionary<int, Floor>(_totalFloors);
        }

        public Floor GetFloor(int floorNumber)
        {
            if (!_floors.ContainsKey(floorNumber))
            {
                _floors.Add(floorNumber, new Floor(floorNumber));
            }

            return _floors[floorNumber];
        }
    }
}
