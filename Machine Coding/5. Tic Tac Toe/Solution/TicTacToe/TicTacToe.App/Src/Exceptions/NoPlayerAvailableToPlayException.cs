namespace TicTacToe.App.Src.Exceptions
{
    internal class NoPlayerAvailableToPlayException : Exception
    {
        public NoPlayerAvailableToPlayException(string message = "No player available to play") : base(message)
        {
        }
    }
}
