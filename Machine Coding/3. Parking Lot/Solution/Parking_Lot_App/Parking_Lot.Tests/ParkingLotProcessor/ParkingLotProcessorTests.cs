using Xunit;
using Parking_Lot.App.src;
using Parking_Lot.App.src.Enums;
using System;

namespace Parking_Lot.Tests.ParkingLotProcessor
{
    public class ParkingLotProcessorTests
    {
        [Theory]        
        [InlineData(InputMode.File)]
        //[InlineData(InputMode.CommandLine)]
        public void CheckProcessing(InputMode inputMode)
        {
            // Arrange
            Processor processor = new Processor(inputMode);

            // Act
            Action act = () => processor.StartProcessing();
        }
    }
}
