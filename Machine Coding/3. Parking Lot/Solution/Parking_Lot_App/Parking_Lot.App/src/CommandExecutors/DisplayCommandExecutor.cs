using Parking_Lot.App.src.Enums;
using Parking_Lot.App.src.Exceptions;
using Parking_Lot.App.src.Models;
using Parking_Lot.App.src.Printers;
using Parking_Lot.App.src.Services;
using System;

namespace Parking_Lot.App.src.CommandExecutors
{
    internal class DisplayCommandExecutor : CommandExecutor
    {
        public static string cmd { get => "display"; }

        public DisplayCommandExecutor(Command command, Printer printer, IParkingLotService parkingLotService) 
            : base(command, printer, parkingLotService)
        {
        }

        public override bool IsApplicable()
        {
            if (cmd.Equals(command.commandName?.Trim()?.ToLower()))
                return true;

            return false;
        }

        public override bool IsValid()
        {
            if (command.param != null && command.param.Count == 2)
            {
                if(Enum.TryParse<DisplayType>(command.param[0]?.Trim(), ignoreCase:true, out DisplayType displayType) && 
                   Enum.TryParse<VehicleType>(command.param[1]?.Trim(), ignoreCase:true, out VehicleType vehicleType))
                    return true;
            }

            return false;
        }

        public override void ExecuteCommand()
        {
            if (IsValid())
            {
                DisplayType displayType = Enum.Parse<DisplayType>(command.param[0]?.Trim(), ignoreCase:true);
                VehicleType vehicleType = Enum.Parse<VehicleType>(command.param[1]?.Trim(), ignoreCase: true);
                int floor = 0;

                switch (displayType)
                {
                    case DisplayType.free_count:
                        floor = 0;
                        var slot = parkingLotService.GetFreeCount(vehicleType).GetEnumerator();
                        while (slot.MoveNext())
                        {
                            printer.Print($"No. of free slots for {vehicleType.ToString()} on Floor {++floor}: {slot.Current}");                            
                        }                        
                        break;

                    case DisplayType.free_slots:
                        floor = 0;
                        var freeSlots = parkingLotService.GetFreeSlots(vehicleType).GetEnumerator();
                        while (freeSlots.MoveNext())
                        {
                            printer.Print($"Free slots for {vehicleType.ToString()} on Floor {++floor}: {freeSlots.Current}");
                        }
                        break;

                    case DisplayType.occupied_slots:
                        floor = 0;
                        var occupiedSlots = parkingLotService.GetOccupiedSlots(vehicleType).GetEnumerator();
                        while (occupiedSlots.MoveNext())
                        {
                            printer.Print($"Occupied slots for {vehicleType.ToString()} on Floor {++floor}: {occupiedSlots.Current}");
                        }
                        break;
                }
            }
            else
            {
                throw new InvalidParameterException();
            }
        }
    }
}
