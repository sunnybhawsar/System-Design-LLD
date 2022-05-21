using Parking_Lot.App.src.Models;
using Parking_Lot.App.src.Printers;
using Parking_Lot.App.src.Services;
using System;

namespace Parking_Lot.App.src.Modes
{
    internal class CommandLineMode : Mode
    {
        public CommandLineMode(Printer printer, IParkingLotService parkingLotService) : base(printer, parkingLotService)
        {

        }

        /// <summary>
        /// Reads command/inputLine from Command Line Interface i.e Interactive Mode
        /// Then processes the command
        /// </summary>
        /// <returns></returns>
        public override Mode Process()
        {
            string inputLine = Console.ReadLine();

            while (inputLine?.Trim()?.ToLower() != "exit")
            {
                Command command = new Command(inputLine);
                ProcessCommand(command);
                inputLine = Console.ReadLine();
            }

            return this;
        }
    }
}
