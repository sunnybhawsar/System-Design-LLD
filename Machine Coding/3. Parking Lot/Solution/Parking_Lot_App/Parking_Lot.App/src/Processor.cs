using Parking_Lot.App.src.Enums;
using Parking_Lot.App.src.Modes;
using Parking_Lot.App.src.Printers;

namespace Parking_Lot.App.src
{
    public class Processor
    {
        private readonly InputMode _inputMode;

        /// <summary>
        /// Entry point of the system
        /// </summary>
        /// <param name="inputMode"></param>
        public Processor(InputMode inputMode)
        {
            _inputMode = inputMode;
        }

        /// <summary>
        /// Based on Input Mode
        /// Reads & processes the commands
        /// </summary>
        public void StartProcessing()
        {
            Printer printer;
            Mode mode;
            switch (_inputMode)
            {
                case InputMode.CommandLine:
                    printer = new CommandLinePrinter();
                    mode = new CommandLineMode(printer).Process();
                    break;

                case InputMode.File:
                    printer = new FilePrinter();
                    mode = new FileMode(printer).Process();
                    break;
            }
        }
    }
}
