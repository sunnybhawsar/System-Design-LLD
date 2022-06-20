using TicTacToe.App.Src.Exceptions;
using TicTacToe.App.Src.Games;
using TicTacToe.App.Src.Models;

namespace TicTacToe.App.Src.Commands
{
    internal class MoveCommandExecutor : CommandExecutor
    {
        internal static string cmd => "Move";

        public MoveCommandExecutor(IGame game, Command command) : base(game, command)
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
            if (_command.param != null && _command.param.Count == 2)
            {
                try
                {
                    Convert.ToInt32(_command.param[0]);
                    Convert.ToInt32(_command.param[1]);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return false;
        }

        internal override void ExecuteCommand()
        {
            if (IsValid())
            {
                int row = Convert.ToInt32(_command.param[0]);
                int col = Convert.ToInt32(_command.param[1]);
                _game.MakeMove(row, col);
            }
            else
                throw new InvalidCommandException();
        }
    }
}
