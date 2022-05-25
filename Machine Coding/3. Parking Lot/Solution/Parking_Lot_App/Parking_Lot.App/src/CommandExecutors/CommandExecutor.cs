using Parking_Lot.App.src.Exceptions;
using Parking_Lot.App.src.Models;
using Parking_Lot.App.src.Printers;
using Parking_Lot.App.src.Services;

namespace Parking_Lot.App.src.CommandExecutors
{
    internal abstract class CommandExecutor
    {
        protected readonly Command command;
        protected readonly Printer printer;
        protected readonly IParkingLotService parkingLotService;

        public CommandExecutor(Command command, Printer printer, IParkingLotService parkingLotService)
        {
            this.command = command;
            this.printer = printer;
            this.parkingLotService = parkingLotService;
        }

        /// <summary>
        /// Checks if the command name matches the applicable executor
        /// </summary>
        /// <returns>bool</returns>
        public abstract bool IsApplicable();

        /// <summary>
        /// Runs basic validations on the coming command object
        /// </summary>
        /// <returns>bool</returns>
        public abstract bool IsValid();

        /// <summary>
        /// Actual work of the executor based on the command
        /// </summary>
        public abstract void ExecuteCommand();

        /// <summary>
        /// Executes command by calling applicable method
        /// </summary>
        public void Execute()
        {
            if (IsApplicable())
                ExecuteCommand();
            else
                throw new ServiceNotAvailableException();
        }
    }
}
