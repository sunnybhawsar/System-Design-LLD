using Parking_Lot.App.src.Enums;
using Parking_Lot.App.src.Exceptions;
using Parking_Lot.App.src.Models;
using Parking_Lot.App.src.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking_Lot.App.src.Services
{
    internal class ParkingLotService : IParkingLotService
    {
        private static IParkingLotService _parkingLotService;
        private ParkingLot _parkingLot;

        #region Singleton

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

        #endregion Singleton

        #region Create

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

        #endregion Create

        #region Park

        /// <summary>
        /// Parks the specific vehicle to the appropriate & nearest slot on the nearest floor
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>Ticket Id</returns>
        public string ParkVehicle(Vehicle vehicle)
        {
            IsParkingLotPresent();

            string ticketId = _parkingLot.id;

            var availableSlot = ParkingScheme.GetAvailableSlot(vehicle.vehicleType, _parkingLot);
            ticketId = _parkingLot.ParkVehicle(vehicle, availableSlot.floorNumber, availableSlot.slotNumber);

            return ticketId;
        }

        #endregion Park

        #region Unpark

        /// <summary>
        /// Un parks the vehicle from the occupied slot based on the valid Ticket Id
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns>Parked vehicle instance</returns>
        public Vehicle UnParkVehicle(string ticketId)
        {
            IsParkingLotPresent();

            Vehicle vehicle = null;
            var parts = ticketId?.Split('_');
            int floorNo = Convert.ToInt32(parts[1]);
            int slotNo = Convert.ToInt32(parts[2]);

            if (floorNo > 0 && floorNo <= _parkingLot.totalFloors && slotNo > 0 &&  slotNo <= _parkingLot.totalSlotsPerFloor)
                vehicle = _parkingLot.UnparkVehicle(floorNo, slotNo);
            else
                throw new ParkingLotException("Invalid Ticket");

            return vehicle;
        }

        #endregion Unpark

        #region Dispay

        /// <summary>
        /// Checks how many slots are available/occupied per floor
        /// </summary>
        /// <param name="parkingLot"></param>
        /// <param name="vehicleType"></param>
        /// <param name="displayType"></param>
        /// <returns>List of slots per floor</returns>
        public List<List<Slot>> GetSlots(ParkingLot parkingLot, VehicleType vehicleType, DisplayType displayType)
        {
            IsParkingLotPresent();

            var slots = parkingLot.floors.Select(x => x.Value.slots).Select(y => y.Select(z => z.Value));
            var freeSlots = slots.Select(x => x.Where(y => y.IsSlotAvailable(vehicleType)).ToList()).ToList();
            var occupiedSlots = slots.Select(x => x.Where(y => !y.IsSlotAvailable(vehicleType)).ToList()).ToList();

            if (displayType == DisplayType.free_slots)
                return freeSlots;
            else
                return occupiedSlots;
        }

        public IList<int> GetFreeCount(VehicleType vehicleType)
        {
            IsParkingLotPresent();
            return DisplayScheme.GetFreeCountOnEachFloor(_parkingLot, vehicleType);
        }

        public IList<string> GetFreeSlots(VehicleType vehicleType)
        {
            IsParkingLotPresent();
            return DisplayScheme.GetFreeSlotsOnEachFloor(_parkingLot, vehicleType);
        }

        public IList<string> GetOccupiedSlots(VehicleType vehicleType)
        {
            IsParkingLotPresent();
            return DisplayScheme.GetOccupiedSlotsOnEachFloor(_parkingLot, vehicleType);
        }

        #endregion Display

        #region Check

        /// <summary>
        /// Checks whether a parking lot created & exits int the system or not
        /// </summary>
        /// <exception cref="ParkingLotException"></exception>
        private void IsParkingLotPresent()
        {
            if (_parkingLot == null)
                throw new ParkingLotException("Parking lot does not exist");
        }

        #endregion Check

        #region Exit

        /// <summary>
        /// Exit
        /// </summary>
        public void Close()
        {
            _parkingLot = null;
            _parkingLotService = null;
        }

        #endregion Exit
    }
}
