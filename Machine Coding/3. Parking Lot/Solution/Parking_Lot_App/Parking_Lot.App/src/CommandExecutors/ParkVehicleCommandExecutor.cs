using Parking_Lot.App.src.Enums;
using Parking_Lot.App.src.Exceptions;
using Parking_Lot.App.src.Models;
using Parking_Lot.App.src.Printers;
using Parking_Lot.App.src.Services;
using System;

namespace Parking_Lot.App.src.CommandExecutors
{
    internal class ParkVehicleCommandExecutor : CommandExecutor
    {
        public static string cmd { get => "park_vehicle"; }

        public ParkVehicleCommandExecutor(Command command, Printer printer, IParkingLotService parkingLotService)
            : base(command, printer, parkingLotService)
        {
        }

        public override bool IsApplicable()
        {
            if (cmd.Equals(command.commandName?.Trim()?.ToLower()))
                return true;

            return false;
        }

        public override bool IsValid()
        {
            if (command.param != null && command.param.Count == 3)
            {
                if(Enum.TryParse<VehicleType>(command.param[0]?.Trim(), ignoreCase:true, out VehicleType vehicleType) &&
                   Enum.TryParse<Color>(command.param[2]?.Trim(), ignoreCase: true, out Color color))
                    return true;
            }

            return false;
        }

        public override void ExecuteCommand()
        {
            if (IsValid())
            {
                VehicleType vehicleType = Enum.Parse<VehicleType>(command.param[0]?.Trim(), ignoreCase:true);
                string regNo = command.param[1]?.Trim();
                Color color = Enum.Parse<Color>(command.param[2]?.Trim(), ignoreCase:true);

                Vehicle vehicle = new Vehicle(vehicleType, regNo, color );

                string ticketId = parkingLotService.ParkVehicle(vehicle);
                printer.Print($"Parked vehicle. Ticket ID: {ticketId}");
            }
            else
            {
                throw new InvalidParameterException();
            }
        }
    }
}
