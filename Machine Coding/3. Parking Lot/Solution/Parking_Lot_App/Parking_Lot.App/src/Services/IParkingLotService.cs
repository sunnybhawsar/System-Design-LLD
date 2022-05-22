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
        void Close();
    }
}
