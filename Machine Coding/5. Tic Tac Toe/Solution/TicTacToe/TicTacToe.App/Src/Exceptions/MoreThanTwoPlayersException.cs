namespace TicTacToe.App.Src.Exceptions
{
    internal class MoreThanTwoPlayersException : Exception
    {
        public MoreThanTwoPlayersException(string message = "Only two players can be registered to play") : base(message)
        {
        }
    }
}
