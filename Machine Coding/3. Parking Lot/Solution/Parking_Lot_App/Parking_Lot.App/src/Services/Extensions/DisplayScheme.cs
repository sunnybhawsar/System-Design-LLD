using Parking_Lot.App.src.Enums;
using Parking_Lot.App.src.Models;
using System.Collections.Generic;

namespace Parking_Lot.App.src.Services.Extensions
{
    internal class DisplayScheme
    {
        internal static IList<int> GetFreeCountOnEachFloor(ParkingLot parkingLot, VehicleType vehicleType)
        {
            IList<int> freeCount = new List<int>();

            var freeSlotNumbers = GetSlotNumbers(parkingLot, vehicleType, DisplayType.free_slots);
            int count = 0;
            foreach (var slot in freeSlotNumbers)
            {
                count = string.IsNullOrEmpty(slot) ? 0 : slot.Split(',').Length;

                freeCount.Add(count);
            }

            return freeCount;
        }

        internal static IList<string> GetFreeSlotsOnEachFloor(ParkingLot parkingLot, VehicleType vehicleType)
        {
            var freeSlotNumbers = GetSlotNumbers(parkingLot, vehicleType, DisplayType.free_slots);
            return freeSlotNumbers;
        }

        internal static IList<string> GetOccupiedSlotsOnEachFloor(ParkingLot parkingLot, VehicleType vehicleType)
        {
            var occupiedSlotNumbers = GetSlotNumbers(parkingLot, vehicleType, DisplayType.occupied_slots);
            return occupiedSlotNumbers;
        }

        /// <summary>
        /// Checks whether the slot is available/occupied on each floor
        /// </summary>
        /// <param name="parkingLot"></param>
        /// <param name="vehicleType"></param>
        /// <param name="displayType"></param>
        /// <returns>List of comma separated slot numbers</returns>
        private static IList<string> GetSlotNumbers(ParkingLot parkingLot, VehicleType vehicleType, DisplayType displayType)
        {
            IList<string> freeSlotNumbers = new List<string>();
            IList<string> occupiedSlotNumber = new List<string>();
            string freeSlots;
            string occupiedSlots;
            Slot slot;

            for (int i = 1; i <= parkingLot?.totalFloors; i++)
            {
                freeSlots = string.Empty;
                occupiedSlots = string.Empty;
                for (int j = 1; j <= parkingLot.totalSlotsPerFloor; j++)
                {
                    slot = parkingLot.GetFloor(i).GetSlot(j);
                    if (slot.slotType == vehicleType)
                    {
                        if (slot.IsSlotAvailable(vehicleType))
                        {
                            if (string.IsNullOrEmpty(freeSlots))
                                freeSlots += $"{j}";
                            else
                                freeSlots += $",{j}";
                        }
                        else if (!slot.IsSlotAvailable(vehicleType))
                        {
                            if (string.IsNullOrEmpty(occupiedSlots))
                                occupiedSlots += $"{j}";
                            else
                                occupiedSlots += $",{j}";
                        }
                    }
                }
                freeSlotNumbers.Add(freeSlots);
                occupiedSlotNumber.Add(occupiedSlots);
            }

            if (displayType == DisplayType.free_slots)
                return freeSlotNumbers;
            else
                return occupiedSlotNumber;
        }
    }
}
