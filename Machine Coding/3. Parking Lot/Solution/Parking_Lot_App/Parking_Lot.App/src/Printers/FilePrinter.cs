using Parking_Lot.App.src.Utilities;
using System.IO;

namespace Parking_Lot.App.src.Printers
{
    internal class FilePrinter : Printer
    {
        private static FilePrinter _filePrinter;
        private object _lock = new object();
        private readonly string _directory;
        private readonly string _fileName;

        /// <summary>
        /// Singleton
        /// </summary>
        private FilePrinter() : base()
        {            
            _directory = DirectoryHelper.Instance.GetCurrentDirectory() + ConfigReader.Instance.GetValue("FileMode:FolderName");
            _fileName = ConfigReader.Instance.GetValue("FileMode:OutputFileName");

            // Clear the output file once
            File.WriteAllText(_directory + _fileName + ".txt", "");
        }

        /// <summary>
        /// Returns Singleton instance of the FilePrinter
        /// </summary>
        public static FilePrinter Instance
        {
            get
            {
                if(_filePrinter == null)
                    _filePrinter = new FilePrinter();

                return _filePrinter;
            }
        }

        /// <summary>
        /// Print to the output file when Input Mode is File
        /// </summary>
        /// <param name="outputLine"></param>
        public override void Print(string outputLine)
        {
            lock (_lock)
            {
                using StreamWriter streamWriter = File.AppendText(_directory + _fileName + ".txt");
                streamWriter.WriteLine(outputLine);
            }
        }
    }
}
