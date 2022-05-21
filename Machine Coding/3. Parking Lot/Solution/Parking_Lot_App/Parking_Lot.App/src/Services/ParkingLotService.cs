using Parking_Lot.App.src.Exceptions;
using Parking_Lot.App.src.Models;

namespace Parking_Lot.App.src.Services
{
    internal class ParkingLotService : IParkingLotService
    {
        private static IParkingLotService _parkingLotService;
        private ParkingLot _parkingLot;

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
