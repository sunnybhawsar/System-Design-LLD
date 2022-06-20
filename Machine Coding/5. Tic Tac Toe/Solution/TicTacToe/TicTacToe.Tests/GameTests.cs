using TicTacToe.App.Src.Games;
using TicTacToe.App.Src.Models;
using TicTacToe.App.Src.Printers;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTests
    {
        private static int _boardSize = 3;


        [Fact]
        public void Game_1()
        {
            // Arrange
            IGame game = Game.Instance(_boardSize, FilePrinter.Instance);
            game.RegisterPlayer(new Player("Sunny", 'X'));
            game.RegisterPlayer(new Player("Bunny", 'O'));

            // Act
            game.MakeMove(1, 1);
            game.MakeMove(1, 3);
            game.MakeMove(3, 1);
            game.MakeMove(2, 1);
            game.MakeMove(3, 3);
            game.MakeMove(2, 2);
            game.MakeMove(3, 2);
        }
    }
}
