using Parking_Lot.App.src.Enums;
using Parking_Lot.App.src.Exceptions;
using Parking_Lot.App.src.Models;

namespace Parking_Lot.App.src.Services
{
    internal class AvailableSlot
    {
        internal int floorNumber { get; set; }
        internal int slotNumber { get; set; }
    }

    internal class ParkingScheme
    {
        internal static AvailableSlot GetAvailableSlot(Vehicle vehicle, ParkingLot parkingLot)
        {
            AvailableSlot availableSlot = new AvailableSlot();

            FindSlot(vehicle, parkingLot, ref availableSlot);

            return availableSlot;
        }

        /// <summary>
        /// Finds the specific slot for the specific vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="parkingLot"></param>
        /// <param name="availableSlot"></param>
        private static void FindSlot(Vehicle vehicle, ParkingLot parkingLot, ref AvailableSlot availableSlot)
        {

            switch (vehicle.vehicleType)
            {
                case VehicleType.CAR:
                    if (parkingLot.totalSlotsPerFloor > 3)
                        Find(1, 4, 4, parkingLot.totalSlotsPerFloor, vehicle, parkingLot, ref availableSlot);
                    else
                        ThrowParkingLotIsFullException();
                    break;

                case VehicleType.BIKE:
                    if (parkingLot.totalSlotsPerFloor > 1)
                        Find(1, 2, 2, 3, vehicle, parkingLot, ref availableSlot);
                    else
                        ThrowParkingLotIsFullException();
                    break;

                case VehicleType.TRUCK:
                    if (parkingLot.totalSlotsPerFloor > 0)
                        Find(1, 1, 1, 1, vehicle, parkingLot, ref availableSlot);
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
            Vehicle vehicle, ParkingLot parkingLot, ref AvailableSlot availableSlot)
        {
            if (x >= parkingLot.totalFloors && y > totalApplicableSlot)
                ThrowParkingLotIsFullException();

            if (parkingLot.GetFloor(x).GetSlot(y).IsSlotAvailable(vehicle))
            {
                availableSlot.floorNumber = x;
                availableSlot.slotNumber = y;
                return;
            }
            else if (x <= parkingLot.totalFloors && y < totalApplicableSlot)
            {
                Find(x, y + 1, initialSlotNo, totalApplicableSlot, vehicle, parkingLot, ref availableSlot);
            }
            else if (x < parkingLot.totalFloors && y == totalApplicableSlot)
            {
                Find(x + 1, initialSlotNo, initialSlotNo, totalApplicableSlot, vehicle, parkingLot, ref availableSlot);
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
