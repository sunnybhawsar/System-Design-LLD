using Parking_Lot.App.src.Models;
using Parking_Lot.App.src.Printers;
using Parking_Lot.App.src.Services;
using System;
using System.Collections.Generic;

namespace Parking_Lot.App.src.CommandExecutors
{
    internal class CommandExecutorFactory
    {
        private IDictionary<string, CommandExecutor> _commands;
        private Command _command;

        /// <summary>
        /// Keeps track of every Command Executors based on the commands coming to the system
        /// Note: Do add new command executor in the factory whenever created for any new command
        /// </summary>
        /// <param name="command"></param>
        /// <param name="printer"></param>
        public CommandExecutorFactory(Command command, Printer printer, IParkingLotService parkingLotService)
        {
            _command = command;
            _commands = new Dictionary<string, CommandExecutor>();

            // Add command executors
            _commands.Add(CreateParkingLotCommandExecutor.cmd, new CreateParkingLotCommandExecutor(command, printer, parkingLotService));
            _commands.Add(ParkVehicleCommandExecutor.cmd, new ParkVehicleCommandExecutor(command, printer, parkingLotService));
            _commands.Add(UnparkVehicleCommandExecutor.cmd, new UnparkVehicleCommandExecutor(command, printer, parkingLotService));
            _commands.Add(DisplayCommandExecutor.cmd, new DisplayCommandExecutor(command, printer, parkingLotService));
            _commands.Add(ExitCommandExecutor.cmd, new ExitCommandExecutor(command, printer, parkingLotService));
        }

        /// <summary>
        /// To get the instance of valid Command Executor
        /// </summary>
        /// <returns>CommandExecutor</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public CommandExecutor GetCommandExecutor()
        {
            CommandExecutor commandExecutor = null;
            if(_command != null && _commands.Count > 0 && _commands.ContainsKey(_command.commandName))
                commandExecutor = _commands[_command.commandName];

            if (commandExecutor == null)
                throw new InvalidOperationException("Invalid Command");

            return commandExecutor;
        }
    }
}
