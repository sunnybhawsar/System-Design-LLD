using Parking_Lot.App.src.Exceptions;
using Parking_Lot.App.src.Models;
using Parking_Lot.App.src.Printers;
using Parking_Lot.App.src.Services;
using System.Text.RegularExpressions;

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
            if (command.param != null 
                && command.param.Count == 1 
                && !string.IsNullOrEmpty(command.param[0])
                && command.param[0].Contains('_')
                //&& Regex.Match(command.param[0].Trim(), @"^\w\+_?\d{1}\+_?\d{1}", RegexOptions.IgnoreCase).Success
                )
            {
                return true;
            }

            return false;
        }

        public override void ExecuteCommand()
        {
            if (IsValid())
            {
                string ticketId = command.param[0]?.Trim();
                Vehicle vehicle = parkingLotService.UnParkVehicle(ticketId);

                printer.Print($"Unparked vehicle with Registration Number: {vehicle?.registrationNumber} and Color: {vehicle?.color.ToString()}");
            }
            else
            {
                throw new InvalidParameterException();
            }
        }
    }
}
