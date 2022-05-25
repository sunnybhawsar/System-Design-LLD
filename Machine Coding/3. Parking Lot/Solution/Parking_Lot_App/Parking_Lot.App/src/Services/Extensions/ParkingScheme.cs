using Parking_Lot.App.src.Enums;
using Parking_Lot.App.src.Exceptions;
using Parking_Lot.App.src.Models;

namespace Parking_Lot.App.src.Services.Extensions
{
    internal class AvailableSlot
    {
        internal int floorNumber { get; set; }
        internal int slotNumber { get; set; }
    }

    internal class ParkingScheme
    {
        internal static AvailableSlot GetAvailableSlot(VehicleType vehicleType, ParkingLot parkingLot)
        {
            AvailableSlot availableSlot = new AvailableSlot();

            FindSlot(vehicleType, parkingLot, ref availableSlot);

            return availableSlot;
        }

        /// <summary>
        /// Finds the specific slot for the specific vehicle
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <param name="parkingLot"></param>
        /// <param name="availableSlot"></param>
        private static void FindSlot(VehicleType vehicleType, ParkingLot parkingLot, ref AvailableSlot availableSlot)
        {

            switch (vehicleType)
            {
                case VehicleType.CAR:
                    if (parkingLot.totalSlotsPerFloor > 3)
                        Find(1, 4, 4, parkingLot.totalSlotsPerFloor, vehicleType, parkingLot, ref availableSlot);
                    else
                        ThrowParkingLotIsFullException();
                    break;

                case VehicleType.BIKE:
                    if (parkingLot.totalSlotsPerFloor > 1)
                        Find(1, 2, 2, 3, vehicleType, parkingLot, ref availableSlot);
                    else
                        ThrowParkingLotIsFullException();
                    break;

                case VehicleType.TRUCK:
                    if (parkingLot.totalSlotsPerFloor > 0)
                        Find(1, 1, 1, 1, vehicleType, parkingLot, ref availableSlot);
                    else
                        ThrowParkingLotIsFullException();
                    break;
            }

        }

        /// <summary>
        /// Finds the avaialbe slot recursively
        /// O(totalFloors) for TRUCK & BIKE
        /// O(totalFloors * totalSlotsPerFloor) for CAR
        /// </summary>
        private static void Find(int x, int y, int initialSlotNo, int totalApplicableSlot,
            VehicleType vehicleType, ParkingLot parkingLot, ref AvailableSlot availableSlot)
        {
            if (x >= parkingLot.totalFloors && y > totalApplicableSlot)
                ThrowParkingLotIsFullException();

            if (parkingLot.GetFloor(x).GetSlot(y).IsSlotAvailable(vehicleType))
            {
                availableSlot.floorNumber = x;
                availableSlot.slotNumber = y;
                return;
            }
            else if (x <= parkingLot.totalFloors && y < totalApplicableSlot)
            {
                Find(x, y + 1, initialSlotNo, totalApplicableSlot, vehicleType, parkingLot, ref availableSlot);
            }
            else if (x < parkingLot.totalFloors && y == totalApplicableSlot)
            {
                Find(x + 1, initialSlotNo, initialSlotNo, totalApplicableSlot, vehicleType, parkingLot, ref availableSlot);
            }
            else
            {
                ThrowParkingLotIsFullException();
            }
        }

        private static void ThrowParkingLotIsFullException()
        {
            throw new ParkingLotException("Parking Lot Full");
        }
    }
}
