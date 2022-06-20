using TicTacToe.App.Src.Utilities;

namespace TicTacToe.App.Src.Printers
{
    public class FilePrinter : IPrinter
    {
        private static FilePrinter? _instance;
        private static Object _obj = new Object();
        private readonly string _currentDirectory;
        private readonly string _fileName;

        /// <summary>
        /// Singleton
        /// </summary>
        private FilePrinter()
        {
            _currentDirectory = DirectoryHelper.GetCurrentDirectory();
            _fileName = "IO/Output1.txt";

            // Clear the file once
            using StreamWriter streamWriter = new StreamWriter($"{_currentDirectory}{_fileName}");
            streamWriter.Write(string.Empty);
        }

        /// <summary>
        /// Get singleton instance of File Printer
        /// </summary>
        public static FilePrinter Instance
        {
            get
            {
                lock (_obj)
                    if (_instance == null)
                        _instance = new FilePrinter();

                return _instance;
            }
        }


        public void Print(string text)
        {
            lock (_obj)
            {
                using StreamWriter streamWriter = new StreamWriter($"{_currentDirectory}{_fileName}", append: true);
                streamWriter.Write(text);
            }
        }
    }
}
