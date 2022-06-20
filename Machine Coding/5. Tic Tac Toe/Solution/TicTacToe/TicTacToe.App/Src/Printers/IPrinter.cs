namespace TicTacToe.App.Src.Printers
{
    public interface IPrinter
    {
        /// <summary>
        /// Prints the text(output) to desired location based on the mode
        /// </summary>
        /// <param name="text"></param>
        void Print(string text);
    }
}
