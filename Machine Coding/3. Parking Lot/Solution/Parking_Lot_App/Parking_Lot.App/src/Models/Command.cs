using System.Collections.Generic;

namespace Parking_Lot.App.src.Models
{
    internal class Command
    {
        internal string commandName { get; set; }
        internal List<string> param { get; set; }

        public Command(string inputLine)
        {
            var arr = inputLine.Split(' ');
            commandName = arr[0];

            param = new List<string>(arr);
            if (param.Count > 1)
                param.RemoveAt(0);
        }
    }
}
