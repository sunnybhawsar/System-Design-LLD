using TicTacToe.App.Src.Commands;
using TicTacToe.App.Src.Games;
using TicTacToe.App.Src.Models;
using TicTacToe.App.Src.Printers;

namespace TicTacToe.App.Src.Modes
{
    internal abstract class Mode
    {
        private readonly IGame _game;
        private readonly IPrinter _printer;

        public Mode(IGame game, IPrinter printer)
        {
            _game = game;
            _printer = printer;
        }

        internal void ProcessCommand(Command command)
        {
            try
            {
                var commandExecutor = new CommandExecutorFactory(_game, command).GetCommandExecutor();
                commandExecutor.Execute();
            }
            catch (Exception ex)
            {
                _printer.Print($"{ex.Message} \n");
            }
        }

        internal abstract Mode Process();
    }
}
