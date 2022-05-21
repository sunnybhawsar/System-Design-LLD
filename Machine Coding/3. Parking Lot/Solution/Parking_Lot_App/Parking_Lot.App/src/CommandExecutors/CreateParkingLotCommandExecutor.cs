using Parking_Lot.App.src.Exceptions;
using Parking_Lot.App.src.Models;
using Parking_Lot.App.src.Printers;
using System;
using System.Linq;

namespace Parking_Lot.App.src.CommandExecutors
{
    internal class CreateParkingLotCommandExecutor : CommandExecutor
    {
        public static string cmd { get => "create_parking_lot"; }

        public CreateParkingLotCommandExecutor(Command command, Printer printer) : base(command, printer)
        {
        }

        public override bool IsApplicable()
        {
            if (cmd.Equals(command.commandName))
                return true;

            return false;
        }

        public override bool IsValid()
        {
            if (command.param != null && command.param.Count == 3)
                return true;

            return false;
        }

        public override void ExecuteCommand()
        {
            if (IsValid())
            {
                string parkingLotId = command.param[0]?.Trim()?.ToUpper();
                int totalFloors = Convert.ToInt32(command.param[1]?.Trim());
                int totalslotsPerFloor = Convert.ToInt32(command.param[2]?.Trim());

                ParkingLot parkingLot = new ParkingLot(parkingLotId, totalFloors, totalslotsPerFloor);

                printer.Print($"Created parking lot with {command.param.ElementAt(1)} floors and {command.param.ElementAt(2)} slots per floor");
            }
            else
            {
                throw new InvalidParameterException();
            }
        }
    }
}
