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

        /// <summary>
        /// Makes applicable move on the game board for the player
        /// </summary>
        /// <param name="player"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <exception cref="InvalidMoveException"></exception>
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

        /// <summary>
        /// Checks the winner after each move on the board for row/col/diagonal/reverseDiagonal
        /// </summary>
        /// <remarks>
        /// Player wins when he/she makes a move
        /// </remarks>
        /// <param name="player"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void CheckWinner(Player player, int row, int col)
        {
            bool isRowWin = true;
            bool isColWin = true;
            bool isDiagonalWin = true;
            bool isRevDiagonalWin = true;

            for (int i = 0; i < _size; i++)
            {
                if (_board[row, i] != player.Symbol)
                    isRowWin = false;
                if (_board[i, col] != player.Symbol)
                    isColWin = false;
                if (_board[i, i] != player.Symbol)
                    isDiagonalWin = false;
                if (_board[i, _size - 1 - col] != player.Symbol)
                    isRevDiagonalWin = false;
            }

            if (isRowWin || isColWin || isDiagonalWin || isRevDiagonalWin)
                _printer.Print($"{player.Name} won the game \n");
            else if (_moveCounter == _size * _size)
                _printer.Print("Game Over");
        }
    }
}
