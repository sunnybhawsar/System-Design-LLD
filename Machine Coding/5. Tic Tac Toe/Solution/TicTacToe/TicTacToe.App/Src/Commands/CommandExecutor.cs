using TicTacToe.App.Src.Games;
using TicTacToe.App.Src.Models;

namespace TicTacToe.App.Src.Commands
{
    internal abstract class CommandExecutor
    {
        protected readonly IGame _game;
        protected readonly Command _command;

        public CommandExecutor(IGame game, Command command)
        {
            _game = game;
            _command = command;
        }

        internal abstract bool IsApplicable();
        internal abstract bool IsValid();
        internal abstract void ExecuteCommand();

        internal void Execute()
        {
            if (IsApplicable())
                ExecuteCommand();
        }
    }
}
