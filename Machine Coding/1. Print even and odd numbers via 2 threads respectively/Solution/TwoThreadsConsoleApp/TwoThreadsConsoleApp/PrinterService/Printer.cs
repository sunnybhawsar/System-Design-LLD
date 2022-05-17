using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TwoThreadsConsoleApp.PrinterService
{
    public class Printer
    {
        private int _maxValue { get; set; }
        private int _currentValue { get; set; }
        private PrinterState _printerState { get; set; }
        private PrinterType _currentPrinterType { get; set; }
        private PrinterType _nextPrinterType { get; set; }

        public Printer(int maxValue, int startValue, PrinterState printerState, PrinterType currentPrintType, PrinterType nextPrinterType)
        {
            _maxValue = maxValue;
            _currentValue = startValue;
            _printerState = printerState;
            _currentPrinterType = currentPrintType;
            _nextPrinterType = nextPrinterType;
        }

        public void Print()
        {
            while (_currentValue <= _maxValue)
            {
                while (_currentPrinterType != _printerState.nextPrinter)
                {
                    Thread.Yield();
                }

                Console.WriteLine($"{Thread.CurrentThread.Name}: {_currentValue}");
                _currentValue += 2;
                _printerState.nextPrinter = _nextPrinterType;
            }
        }
    }
}
