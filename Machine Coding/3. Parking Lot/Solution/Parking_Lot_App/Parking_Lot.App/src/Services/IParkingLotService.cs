using Parking_Lot.App.src.Enums;
using Parking_Lot.App.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot.App.src.Services
{
    internal interface IParkingLotService
    {
        void CreateParkingLot(ParkingLot parkingLot);
        string ParkVehicle(Vehicle vehicle);
        Vehicle UnParkVehicle(string ticketId);
        List<List<Slot>> GetSlots(ParkingLot parkingLot, VehicleType vehicleType, DisplayType displayType);
        IList<int> GetFreeCount(VehicleType vehicleType);
        IList<string> GetFreeSlots(VehicleType vehicleType);
        IList<string> GetOccupiedSlots(VehicleType vehicleType);
        void Close();
    }
}
