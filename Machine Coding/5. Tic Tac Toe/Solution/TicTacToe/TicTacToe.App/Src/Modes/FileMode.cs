using TicTacToe.App.Src.Games;
using TicTacToe.App.Src.Models;
using TicTacToe.App.Src.Printers;
using TicTacToe.App.Src.Utilities;

namespace TicTacToe.App.Src.Modes
{
    internal class FileMode : Mode
    {
        private readonly string _currentDirectory;
        private readonly string _folderName;
        private readonly string _fileName;
        public FileMode(IGame game, IPrinter printer) : base(game, printer)
        {
            _currentDirectory = DirectoryHelper.GetCurrentDirectory();
            _folderName = ConfigReader.Instance.GetValue("FileMode:Folder");
            _fileName = ConfigReader.Instance.GetValue("FileMode:InputFile");
        }

        internal override Mode Process()
        {
            try
            {
                foreach (var inputLine in File.ReadLines($"{_currentDirectory}{_folderName}{_fileName}"))
                {
                    Command command = new Command(inputLine);
                    ProcessCommand(command);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return this;
        }
    }
}
