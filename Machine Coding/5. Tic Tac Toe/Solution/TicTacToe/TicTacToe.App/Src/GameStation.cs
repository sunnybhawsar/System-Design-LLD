using TicTacToe.App.Src.enums;
using TicTacToe.App.Src.Games;
using TicTacToe.App.Src.Modes;
using TicTacToe.App.Src.Printers;

namespace TicTacToe.App.Src
{
    internal class GameStation
    {
        private readonly InputMode _inputMode;
        private readonly int _size;

        public GameStation(InputMode inputMode, int size)
        {
            _inputMode = inputMode;
            _size = size;
        }

        internal void Play()
        {
            switch (_inputMode)
            {
                case InputMode.File:
                    IPrinter printer = FilePrinter.Instance;
                    Mode mode = new Modes.FileMode(Game.Instance(_size, printer), printer).Process();
                    break;
            }
        }
    }
}
