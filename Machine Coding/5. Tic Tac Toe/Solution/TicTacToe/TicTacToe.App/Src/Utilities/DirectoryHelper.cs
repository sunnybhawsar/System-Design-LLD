namespace TicTacToe.App.Src.Utilities
{
    internal class DirectoryHelper
    {
        internal static string GetCurrentDirectory()
        {
            string dir = Directory.GetCurrentDirectory();

            dir = dir.Contains("bin\\Debug\\net6.0") ? dir.Replace("bin\\Debug\\net6.0", "") : dir;

            return dir;
        }
    }
}
