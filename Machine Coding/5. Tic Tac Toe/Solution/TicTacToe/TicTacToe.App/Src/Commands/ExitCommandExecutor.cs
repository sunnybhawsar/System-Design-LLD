using TicTacToe.App.Src.Exceptions;
using TicTacToe.App.Src.Games;
using TicTacToe.App.Src.Models;

namespace TicTacToe.App.Src.Commands
{
    internal class ExitCommandExecutor : CommandExecutor
    {
        internal static string cmd => "Exit";

        public ExitCommandExecutor(IGame game, Command command) : base(game, command)
        {
        }

        internal override bool IsApplicable()
        {
            if (_command.Name == cmd)
                return true;

            return false;
        }

        internal override bool IsValid()
        {
            if (_command.Name == "Exit")
                return true;

            return false;
        }

        internal override void ExecuteCommand()
        {
            if (IsValid())
            {
                _game.EndGame();
            }
            else
                throw new InvalidCommandException();
        }
    }
}
