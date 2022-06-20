using TicTacToe.App.Src.Exceptions;
using TicTacToe.App.Src.Printers;

namespace TicTacToe.App.Src.Models
{
    internal class GameBoard
    {
        private char[,] _board;
        private readonly int _size;
        private readonly IPrinter _printer;
        internal int _moveCounter;

        internal GameBoard(int size, IPrinter printer)
        {
            _size = size;
            _printer = printer;
            _moveCounter = 0;

            Initialize();
        }

        /// <summary>
        /// Initializes the Game Board with '-'
        /// </summary>
        private void Initialize()
        {
            _board = new char[_size, _size];

            for (int i = 0; i < _board.GetLength(0); i++)
                for (int j = 0; j < _board.GetLength(1); j++)
                    _board[i, j] = '-';

            PrintBoard();
        }

        /// <summary>
        /// Prints the Game Board
        /// </summary>
        private void PrintBoard()
        {
            string text = string.Empty;

            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    text += $"{_board[i, j]} ";
                }
                text += $"\n";
            }

            _printer.Print(text);
        }


        internal void MakeMove(Player player, int row, int col)
        {
            if (row >= 0 && col >= 0 && row < _size && col < _size && _board[row, col] == '-')
            {
                _board[row, col] = player.Symbol;
                _moveCounter++;
                PrintBoard();
                CheckWinner(player, row, col);
            }
            else
                throw new InvalidMoveException();
        }

        private void CheckWinner(Player player, int row, int col)
        {
            bool isRowDone = true;
            bool isColDone = true;
            bool isDiagonalDone = true;
            bool isRevDiagonalDone = true;

            for (int i = 0; i < _size; i++)
            {
                if (_board[row, i] != player.Symbol)
                    isRowDone = false;
                if (_board[i, col] != player.Symbol)
                    isColDone = false;
                if (_board[i, i] != player.Symbol)
                    isDiagonalDone = false;
                if (_board[i, _size - 1 - col] != player.Symbol)
                    isRevDiagonalDone = false;
            }

            if (isRowDone || isColDone || isDiagonalDone || isRevDiagonalDone)
                _printer.Print($"{player.Name} won the game \n");
            else if (_moveCounter == _size * _size)
                _printer.Print("Game Over");
        }
    }
}
