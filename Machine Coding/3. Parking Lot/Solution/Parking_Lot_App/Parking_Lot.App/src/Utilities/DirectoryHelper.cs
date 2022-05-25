using System.IO;

namespace Parking_Lot.App.src.Utilities
{
    internal class DirectoryHelper
    {
        private static string _dir;
        private static DirectoryHelper _instance;
        
        /// <summary>
        /// Singleton
        /// </summary>
        private DirectoryHelper()
        {
            _dir = Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// To get the singleton instace of DirectoryHelper
        /// </summary>
        public static DirectoryHelper Instance { 
            get
            {
                if( _instance == null )
                    _instance = new DirectoryHelper();

                return _instance;
            } 
        }

        /// <summary>
        /// Get Current Directory in which bin/Debug/.Net5 is excluded if present
        /// </summary>
        /// <returns>string: Current Directory</returns>
        public string GetCurrentDirectory()
        {
            string currentDirectory = _dir?.Substring(0, _dir.LastIndexOf("Parking_Lot.App") + "Parking_Lot.App\\".Length);

            return currentDirectory;
        }
    }
}
