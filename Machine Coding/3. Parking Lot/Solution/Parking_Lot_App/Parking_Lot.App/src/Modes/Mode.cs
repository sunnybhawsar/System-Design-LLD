using Parking_Lot.App.src.CommandExecutors;
using Parking_Lot.App.src.Models;
using Parking_Lot.App.src.Printers;
using System;

namespace Parking_Lot.App.src.Modes
{
    internal abstract class Mode
    {
        private readonly Printer _printer;

        public Mode(Printer printer)
        {
            _printer = printer;
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
                var commandExecutor = new CommandExecutorFactory(command, _printer).GetCommandExecutor();
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
