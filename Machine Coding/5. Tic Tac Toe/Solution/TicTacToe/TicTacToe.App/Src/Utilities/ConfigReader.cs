using Microsoft.Extensions.Configuration;

namespace TicTacToe.App.Src.Utilities
{
    internal class ConfigReader
    {
        private static ConfigReader? _instance;
        private IConfigurationRoot? _config;

        /// <summary>
        /// Singleton
        /// </summary>
        private ConfigReader()
        {
            string dir = DirectoryHelper.GetCurrentDirectory();
            dir = dir.Contains("TicTacToe.Tests") ? dir.Replace("TicTacToe.Tests", "TicTacToe.App") : dir;

            _config = new ConfigurationBuilder().AddJsonFile($"{dir}appSettings.json").Build();
        }

        /// <summary>
        /// Returns singleton instance of ConfigReader
        /// </summary>
        public static ConfigReader Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ConfigReader();

                return _instance;
            }
        }

        /// <summary>
        /// Get config value from appSettings.json
        /// </summary>
        /// <remarks> key accepts - string and string with : separated keys for nested sections</remarks>
        /// <param name="key"></param>
        /// <returns>string</returns>
        public string? GetValue(string key)
        {
            string value = string.Empty;

            if (key.Contains(':'))
            {
                var parts = key.Split(':');

                if (parts.Length > 0)
                {
                    IConfigurationSection section = _config.GetSection(parts[0]?.Trim());

                    for (int i = 1; i < parts.Length; i++)
                    {
                        section = section?.GetSection(parts[i]?.Trim());
                    }

                    value = section?.Value;
                }
            }
            else
            {
                value = _config.GetSection(key)?.Value;
            }

            return value;
        }

        public IConfigurationRoot? GetConfigurationRoot()
        {
            return _config;
        }
    }
}
