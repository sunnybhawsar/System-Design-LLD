using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoThreadsConsoleApp.PrinterService
{
    public class PrinterState
    {
        public PrinterType nextPrinter;

        public PrinterState(PrinterType nextPrinter)
        {
            this.nextPrinter = nextPrinter;
        }
    }
}
