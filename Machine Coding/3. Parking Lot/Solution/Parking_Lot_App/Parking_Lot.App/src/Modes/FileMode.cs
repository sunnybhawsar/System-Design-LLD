using Parking_Lot.App.src.Models;
using Parking_Lot.App.src.Printers;
using Parking_Lot.App.src.Utilities;
using System;
using System.IO;

namespace Parking_Lot.App.src.Modes
{
    internal class FileMode : Mode
    {
        private readonly Printer _printer;
        private readonly string _directory;
        private readonly string _fileName;        

        public FileMode(Printer printer) : base(printer)
        {            
            _printer = printer;
            _directory = ConfigReader.Instance.GetValue("FileMode:FileDirectory");
            _fileName = ConfigReader.Instance.GetValue("FileMode:InputFileName");
        }

        /// <summary>
        /// Reads command/inputLine from a File
        /// Then processes the command
        /// </summary>
        /// <returns></returns>
        public override Mode Process()
        {
            try
            {
                foreach (var inputLine in File.ReadLines(_directory + _fileName + ".txt"))
                {
                    Command command = new Command(inputLine);
                    ProcessCommand(command);
                }
            }
            catch (Exception ex)
            {
                _printer.Print(ex.ToString());
            }

            return this;
        }
    }
}
