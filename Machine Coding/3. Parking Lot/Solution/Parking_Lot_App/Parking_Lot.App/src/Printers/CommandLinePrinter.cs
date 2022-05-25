using System;

namespace Parking_Lot.App.src.Printers
{
    internal class CommandLinePrinter : Printer
    {
        private static CommandLinePrinter _commandLinePrinter;

        /// <summary>
        /// Singleton
        /// </summary>
        private CommandLinePrinter() : base()
        {
        }

        /// <summary>
        /// Returns Singleton instance of the CommandLinePrinter
        /// </summary>
        public static CommandLinePrinter Instance
        {
            get
            {
                if (_commandLinePrinter == null)
                    _commandLinePrinter = new CommandLinePrinter();

                return _commandLinePrinter;
            }
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
