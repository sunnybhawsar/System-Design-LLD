using Parking_Lot.App.src.CommandExecutors;
using Parking_Lot.App.src.Models;
using Parking_Lot.App.src.Printers;
using Parking_Lot.App.src.Services;
using System;

namespace Parking_Lot.App.src.Modes
{
    internal abstract class Mode
    {
        private readonly Printer _printer;
        private readonly IParkingLotService _parkingLotService;

        public Mode(Printer printer, IParkingLotService parkingLotService)
        {
            _printer = printer;
            _parkingLotService = parkingLotService;
        }

        /// <summary>
        /// Abstract Process method will call this common method for processing
        /// </summary>
        /// <param name="command"></param>
        public void ProcessCommand(Command command)
        {
            try
            {
                // Executes command based on the command name
                var commandExecutor = new CommandExecutorFactory(command, _printer, _parkingLotService).GetCommandExecutor();
                commandExecutor.Execute();
            }
            catch (Exception ex)
            {
                _printer.Print(ex.Message);
            }
        }

        public abstract Mode Process();
    }
}
