using TicTacToe.App.Src.Models;

namespace TicTacToe.App.Src.Games
{
    public interface IGame
    {
        /// <summary>
        /// To register the player
        /// </summary>
        /// <param name="player"></param>
        void RegisterPlayer(Player player);

        /// <summary>
        /// To make the move on the board
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <exception cref="GameBoardNotAvailableException"></exception>
        void MakeMove(int row, int col);

        /// <summary>
        /// Clears the resources at the end
        /// </summary>
        void EndGame();
    }
}
