namespace TicTacToe.App.Src.Exceptions
{
    internal class InvalidMoveException : Exception
    {
        public InvalidMoveException(string message = "Invalid Move") : base(message)
        {
        }
    }
}
