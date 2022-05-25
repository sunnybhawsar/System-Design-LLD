using System.Collections.Generic;

namespace Parking_Lot.App.src.Models
{
    internal class Command
    {
        internal string commandName { get; set; }
        internal List<string> param { get; set; }

        public Command(string inputLine)
        {
            if (!string.IsNullOrEmpty(inputLine) && inputLine.Contains(" "))
            {
                var arr = inputLine.Split(' ');
                if (arr?.Length > 0)
                {
                    commandName = arr[0];

                    param = new List<string>(arr);
                    if (param.Count > 1)
                        param.RemoveAt(0);
                }
            }
            else
            {
                commandName = inputLine;
            }
        }
    }
}
