using Parking_Lot.App.src.Exceptions;
using Parking_Lot.App.src.Models;
using Parking_Lot.App.src.Printers;
using Parking_Lot.App.src.Services;

namespace Parking_Lot.App.src.CommandExecutors
{
    internal class UnparkVehicleCommandExecutor : CommandExecutor
    {
        public static string cmd { get => "unpark_vehicle"; }

        public UnparkVehicleCommandExecutor(Command command, Printer printer, IParkingLotService parkingLotService)
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
            if (command.param != null && command.param.Count == 1)
            {
                return true;
            }

            return false;
        }

        public override void ExecuteCommand()
        {
            if (IsValid())
            {
                throw new ServiceNotAvailableException();
            }
            else
            {
                throw new InvalidParameterException();
            }
        }
    }
}
