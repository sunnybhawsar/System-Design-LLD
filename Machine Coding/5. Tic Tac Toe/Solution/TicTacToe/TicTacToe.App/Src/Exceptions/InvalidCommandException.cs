namespace TicTacToe.App.Src.Exceptions
{
    internal class InvalidCommandException : Exception
    {
        public InvalidCommandException(string message = "Invalid Command") : base(message)
        {
        }
    }
}
