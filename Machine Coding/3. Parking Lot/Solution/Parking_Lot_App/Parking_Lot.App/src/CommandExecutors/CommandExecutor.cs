using Parking_Lot.App.src.Exceptions;
using Parking_Lot.App.src.Models;
using Parking_Lot.App.src.Printers;

namespace Parking_Lot.App.src.CommandExecutors
{
    internal abstract class CommandExecutor
    {
        protected readonly Command command;
        protected readonly Printer printer;

        public CommandExecutor(Command command, Printer printer)
        {
            this.command = command;
            this.printer = printer;
        }

        public abstract bool IsApplicable();
        public abstract bool IsValid();
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
