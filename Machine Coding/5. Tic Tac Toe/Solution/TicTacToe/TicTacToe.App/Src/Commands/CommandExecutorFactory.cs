using TicTacToe.App.Src.Exceptions;
using TicTacToe.App.Src.Games;
using TicTacToe.App.Src.Models;

namespace TicTacToe.App.Src.Commands
{
    internal class CommandExecutorFactory
    {
        private IDictionary<string, CommandExecutor> _commands;
        private readonly Command _command;

        /// <summary>
        /// Add all concrete command executors to the factory
        /// </summary>
        /// <param name="game"></param>
        /// <param name="command"></param>
        public CommandExecutorFactory(IGame game, Command command)
        {
            _command = command;

            _commands = new Dictionary<string, CommandExecutor>();
            _commands.Add(RegisterCommandExecutor.cmd, new RegisterCommandExecutor(game, command));
            _commands.Add(MoveCommandExecutor.cmd, new MoveCommandExecutor(game, command));
            _commands.Add(ExitCommandExecutor.cmd, new ExitCommandExecutor(game, command));
        }

        /// <summary>
        /// To get the command executor based on Command
        /// </summary>
        /// <returns>Instace of concrete command executor</returns>
        /// <exception cref="InvalidCommandException"></exception>
        public CommandExecutor GetCommandExecutor()
        {
            if (!string.IsNullOrEmpty(_command.Name) && _commands.ContainsKey(_command.Name))
                return _commands[_command.Name];

            throw new InvalidCommandException();
        }
    }
}
