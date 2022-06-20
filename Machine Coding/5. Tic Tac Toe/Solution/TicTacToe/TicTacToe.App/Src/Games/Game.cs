using TicTacToe.App.Src.Exceptions;
using TicTacToe.App.Src.Models;
using TicTacToe.App.Src.Printers;

namespace TicTacToe.App.Src.Games
{
    public class Game : IGame
    {
        private static Game? _instance;
        private GameBoard? _gameBoard;
        private IList<Player> _players;
        private int _nextPlayer;
        private IPrinter _printer;
        private int _size;

        /// <summary>
        /// Singleton
        /// </summary>
        /// <param name="size"></param>
        /// <param name="printer"></param>
        private Game(int size, IPrinter printer)
        {
            if (_gameBoard == null)
                _gameBoard = new GameBoard(size, printer);

            _players = new List<Player>();
            _nextPlayer = 0;
            _printer = printer;
            _size = size;
        }

        /// <summary>
        /// To get the singleton instance of Game
        /// </summary>
        /// <param name="size"></param>
        /// <param name="printer"></param>
        /// <returns>Instance of Game</returns>
        public static Game Instance(int size, IPrinter printer)
        {
            if (_instance == null)
                _instance = new Game(size, printer);

            return _instance;
        }

        /// <summary>
        /// To register the player
        /// </summary>
        /// <param name="player"></param>
        public void RegisterPlayer(Player player)
        {
            if (_players.Count == 2)
                throw new MoreThanTwoPlayersException();

            if (!_players.Contains(player))
                _players.Add(player);
        }

        /// <summary>
        /// To make the move on the board
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <exception cref="GameBoardNotAvailableException"></exception>
        /// <exception cref="NoPlayerAvailableToPlayException"></exception>
        public void MakeMove(int row, int col)
        {
            if (_gameBoard == null)
                throw new GameBoardNotAvailableException();
            else if (_players.Count != 2)
                throw new NoPlayerAvailableToPlayException();

            _gameBoard.MakeMove(_players[_nextPlayer], row - 1, col - 1);
            SetNextPlayer();
        }

        /// <summary>
        /// Sets the next player after move
        /// </summary>
        private void SetNextPlayer()
        {
            _nextPlayer = _nextPlayer == 0 ? 1 : 0;
        }

        /// <summary>
        /// To end the game
        /// </summary>
        public void EndGame()
        {
            if(_gameBoard?._moveCounter != _size * _size)
                _printer.Print("Game Over");

            _players.Clear();
            _gameBoard = null;
        }
    }
}
