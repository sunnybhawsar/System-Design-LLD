using System;
using System.Threading;
using TwoThreadsConsoleApp.PrinterService;

namespace TwoThreadsConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrinterState printerState = new PrinterState(PrinterType.Odd);
            Printer printer1 = new Printer(50, 1, printerState, PrinterType.Odd, PrinterType.Even);
            Printer printer2 = new Printer(50, 2, printerState, PrinterType.Even, PrinterType.Odd);

            Thread oddThread = new Thread(() => printer1.Print());
            oddThread.Name = "OddThread";

            Thread evenThread = new Thread(() => printer2.Print());
            evenThread.Name = "EvenThread";

            oddThread.Start();
            evenThread.Start();
        }
    }
}
