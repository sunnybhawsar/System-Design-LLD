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

        #region Abstract

        /// <summary>
        /// Checks if the command name matches the applicable executor
        /// </summary>
        /// <returns>true/false</returns>
        internal abstract bool IsApplicable();

        /// <summary>
        /// Runs basic validations on the coming command object
        /// </summary>
        /// <returns>true/false</returns>
        internal abstract bool IsValid();

        /// <summary>
        /// Actual work of the executor based on the command
        /// </summary>
        internal abstract void ExecuteCommand();

        #endregion Abstract

        #region Base

        /// <summary>
        /// Executes command by calling applicable method
        /// </summary>
        internal void Execute()
        {
            if (IsApplicable())
                ExecuteCommand();
        }

        #endregion Base
    }
}
