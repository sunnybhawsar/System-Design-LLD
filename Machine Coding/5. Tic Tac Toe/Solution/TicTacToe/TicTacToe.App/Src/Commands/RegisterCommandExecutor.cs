using TicTacToe.App.Src.Exceptions;
using TicTacToe.App.Src.Games;
using TicTacToe.App.Src.Models;

namespace TicTacToe.App.Src.Commands
{
    internal class RegisterCommandExecutor : CommandExecutor
    {
        internal static string cmd => "Register";

        public RegisterCommandExecutor(IGame game, Command command) : base(game, command)
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
                if (new string[] { "X", "O" }.Contains(_command.param[0]))
                    return true;

            return false;
        }

        internal override void ExecuteCommand()
        {
            if (IsValid())
            {
                Player player = new Player(name: _command.param[1], symbol: Convert.ToChar(_command.param[0]));
                _game.RegisterPlayer(player);
            }
            else
                throw new InvalidCommandException();
        }
    }
}
