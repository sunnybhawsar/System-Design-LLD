using System;

namespace Parking_Lot.App.src.Printers
{
    internal class CommandLinePrinter : Printer
    {
        public CommandLinePrinter() : base()
        {

        }

        /// <summary>
        /// Print to the command line when Input Mode is CommandLine
        /// </summary>
        /// <param name="outputLine"></param>
        public override void Print(string outputLine)
        {
            Console.WriteLine(outputLine);
        }
    }
}
