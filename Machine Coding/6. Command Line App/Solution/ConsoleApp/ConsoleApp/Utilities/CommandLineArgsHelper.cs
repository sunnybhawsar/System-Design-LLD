namespace ConsoleApp.Utilities
{
    internal class CommandLineArgsHelper
    {
        private static CommandLineArgsHelper? _instance = null;

        /// <summary>
        /// Singleton
        /// </summary>
        private CommandLineArgsHelper()
        {
        }

        /// <summary>
        /// Returns singleton instance of CommandLineArgsHelper
        /// </summary>
        internal static CommandLineArgsHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CommandLineArgsHelper();

                return _instance;
            }
        }

        /// <summary>
        /// Takes command line args and fills the values for the reference variables
        /// </summary>
        /// <remarks>
        /// It won't update the value of reference variables if no command line args passed
        /// </remarks>
        /// <param name="args"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        internal void FillValuesFromArgs(string[] args, ref int arg1, ref string arg2, ref string arg3)
        {
            if (args != null && args.Length > 0)
            {
                if (args.Length >= 3)
                {
                    arg1 = Convert.ToInt32(args[0]);
                    arg2 = args[1];
                    arg3 = args[2];
                }
                else if (args.Length == 2)
                {
                    arg1 = Convert.ToInt32(args[0]);
                    arg2 = args[1];
                }
                else
                {
                    arg1 = Convert.ToInt32(args[0]);
                }
            }
        }
    }
}
