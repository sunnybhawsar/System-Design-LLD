using Parking_Lot.App.src.Enums;
using Parking_Lot.App.src.Modes;
using Parking_Lot.App.src.Printers;
using Parking_Lot.App.src.Services;

namespace Parking_Lot.App.src
{
    public class Processor
    {
        private readonly InputMode _inputMode;
        private readonly IParkingLotService _parkingLotService;

        /// <summary>
        /// Entry point of the system
        /// </summary>
        /// <param name="inputMode"></param>
        public Processor(InputMode inputMode)
        {
            _inputMode = inputMode;
            _parkingLotService = ParkingLotService.Instance;
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
                    mode = new CommandLineMode(printer, _parkingLotService).Process();
                    break;

                case InputMode.File:
                    printer = new FilePrinter();
                    mode = new FileMode(printer, _parkingLotService).Process();
                    break;
            }
        }
    }
}
