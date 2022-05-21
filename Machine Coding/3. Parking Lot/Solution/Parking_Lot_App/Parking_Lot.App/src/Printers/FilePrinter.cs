using Parking_Lot.App.src.Utilities;
using System.IO;

namespace Parking_Lot.App.src.Printers
{
    internal class FilePrinter : Printer
    {
        private readonly string _directory;
        private readonly string _fileName;

        public FilePrinter() : base()
        {
            _directory = ConfigReader.Instance.GetValue("FileMode:FileDirectory");
            _fileName = ConfigReader.Instance.GetValue("FileMode:OutputFileName");            
        }

        /// <summary>
        /// Print to the output file when Input Mode is File
        /// </summary>
        /// <param name="outputLine"></param>
        public override void Print(string outputLine)
        {
            using StreamWriter streamWriter = File.AppendText(_directory + _fileName + ".txt");
            streamWriter.WriteLine(outputLine);
        }
    }
}
