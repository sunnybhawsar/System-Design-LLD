using Microsoft.Extensions.Configuration;
using System.IO;

namespace Parking_Lot.App.src.Utilities
{
    internal class ConfigReader
    {
        private static ConfigReader _instance;
        private IConfigurationRoot _configBuilder;

        /// <summary>
        /// Singletone
        /// </summary>
        private ConfigReader()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string dir = currentDirectory.Substring(0, currentDirectory.LastIndexOf("Parking_Lot.App") + "Parking_Lot.App\\".Length);            
            IConfigurationRoot configBuilder = new ConfigurationBuilder()
                                            .AddJsonFile($"{dir}appSettings.json", optional: true, reloadOnChange: true)
                                            .Build();

            _configBuilder = configBuilder;
        }

        /// <summary>
        /// To get the singleton instace of ConfigReader
        /// </summary>
        public static ConfigReader Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                else
                {
                    _instance = new ConfigReader();
                    return _instance;
                }
            }
        }

        /// <summary>
        /// Get config value from appSettings.json
        /// Accepts - string 
        /// Accepts - string with : separated keys for nested sections
        /// </summary>
        /// <param name="key"></param>
        /// <returns>string</returns>
        public string GetValue(string key)
        {
            string value = string.Empty;

            if (key.Contains(':'))
            {
                var parts = key.Split(':');

                if (parts.Length > 0)
                {
                    IConfigurationSection section = _configBuilder.GetSection(parts[0]?.Trim());

                    for (int i = 1; i < parts.Length; i++)
                    {
                        section = section?.GetSection(parts[i]?.Trim());
                    }

                    value = section?.Value;
                }
            }
            else
            {
                value = _configBuilder.GetSection(key)?.Value;
            }

            return value;
        }

        /// <summary>
        /// Get connection string from appSettings.json
        /// </summary>
        /// <param name="name"></param>
        /// <returns>string</returns>
        public string GetConnectionString(string name)
        {
            string connectionString = string.Empty;

            connectionString = _configBuilder.GetConnectionString(name);

            return connectionString;
        }
    }
}
