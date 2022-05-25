using Parking_Lot.App.src;
using Parking_Lot.App.src.Enums;

namespace Parking_Lot.App
{
    internal class Program
    {
        private static readonly InputMode _inputMode = InputMode.File;

        static void Main(string[] args)
        {
            Processor processor = new Processor(_inputMode);
            processor.StartProcessing();
        }
    }
}
