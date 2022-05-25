using Parking_Lot.App.src.Exceptions;
using Parking_Lot.App.src.Models;
using Parking_Lot.App.src.Printers;
using Parking_Lot.App.src.Services;

namespace Parking_Lot.App.src.CommandExecutors
{
    internal class ExitCommandExecutor : CommandExecutor
    {
        public static string cmd { get => "exit"; }

        public ExitCommandExecutor(Command command, Printer printer, IParkingLotService parkingLotService)
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
            if (IsApplicable() && command.param == null)
            {
                return true;
            }

            return false;
        }

        public override void ExecuteCommand()
        {
            if (IsValid())
                parkingLotService.Close();
            else
                throw new InvalidParameterException();
        }
    }
}
