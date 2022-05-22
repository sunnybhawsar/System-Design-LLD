using Parking_Lot.App.src.Exceptions;
using Parking_Lot.App.src.Models;

namespace Parking_Lot.App.src.Services
{
    internal class ParkingLotService : IParkingLotService
    {
        private static IParkingLotService _parkingLotService;
        private ParkingLot _parkingLot;
        private int[,] _chart;

        /// <summary>
        /// Singleton
        /// </summary>
        private ParkingLotService()
        {            
        }

        public static IParkingLotService Instance
        {
            get
            {
                if (_parkingLotService != null)
                    return _parkingLotService;

                _parkingLotService = new ParkingLotService();
                return _parkingLotService;
            }
        }

        /// <summary>
        /// Initialize ParkingLot only once
        /// </summary>
        /// <param name="parkingLot"></param>
        public void CreateParkingLot(ParkingLot parkingLot)
        {
            if (_parkingLot != null)
            {
                throw new ParkingLotException("Parking lot already exists");
            }

            _parkingLot = parkingLot;
            _chart = new int[_parkingLot.totalFloors, _parkingLot.totalSlotsPerFloor];
        }

        /// <summary>
        /// Parks the specific vehicle to the appropriate & nearest slot on the nearest floor
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>Ticket Id</returns>
        public string ParkVehicle(Vehicle vehicle)
        {
            string ticketId = _parkingLot.id;

            var availableSlot = ParkingScheme.GetAvailableSlot(vehicle, _parkingLot);
            ticketId = _parkingLot.ParkVehicle(vehicle, availableSlot.floorNumber, availableSlot.slotNumber);
            _chart[availableSlot.floorNumber - 1, availableSlot.slotNumber - 1] = 1;

            return ticketId;
        }

        /// <summary>
        /// Exit
        /// </summary>
        public void Close()
        {
            _parkingLot = null;
            _parkingLotService = null;
        }        
    }
}
