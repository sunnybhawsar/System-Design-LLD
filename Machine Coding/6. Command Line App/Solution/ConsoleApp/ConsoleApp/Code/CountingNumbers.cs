using ConsoleApp.Utilities;

namespace ConsoleApp.Code
{
    public class CountingNumbers
    {
        private static CommandLineArgsHelper? _cmdArgsHelper;
        private int n;
        private string divisibleBy3;
        private string divisibleBy5;

        /// <summary>
        /// Initializes with default values
        /// </summary>
        public CountingNumbers()
        {
            _cmdArgsHelper = CommandLineArgsHelper.Instance;
            n = 100;
            divisibleBy3 = "fizz";
            divisibleBy5 = "buzz";
        }

        /// <summary>
        /// Returns list of string from 1 - n where n can be passed as command line argument
        /// </summary>
        /// <remarks>
        /// If no command line argument passed then by default n will be 100
        /// </remarks>
        public IList<string> GetResult(string[] args)
        {
            IList<string> result = new List<string>();

            try
            {
                _cmdArgsHelper?.FillValuesFromArgs(args, ref n, ref divisibleBy3, ref divisibleBy5);
            }
            catch (Exception e)
            {
                result.Add("Invalid Input");
                return result;
            }

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    result.Add($"{divisibleBy3} {divisibleBy5}");
                else if (i % 3 == 0)
                    result.Add($"{divisibleBy3}");
                else if (i % 5 == 0)
                    result.Add($"{divisibleBy5}");
                else
                    result.Add(i.ToString());
            }

            return result;
        }
    }
}
