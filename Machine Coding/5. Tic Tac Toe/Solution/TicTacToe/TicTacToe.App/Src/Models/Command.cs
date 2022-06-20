using TicTacToe.App.Src.Exceptions;

namespace TicTacToe.App.Src.Models
{
    internal class Command
    {
        public string? Name { get; set; }
        public IList<string>? param { get; set; }

        /// <summary>
        /// Initializes the properties based on the input string
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="InvalidCommandException"></exception>
        internal Command(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new InvalidCommandException();

            else if (input.Trim().ToLower() == "exit")
                CreateExitCommand();

            else if (input?.Trim()?.Split(' ')?.Length != 2)
                throw new InvalidCommandException();

            else
            {
                var parts = input.Trim().Split(' ');

                if (new string[] { "X", "O" }.Contains(parts[0]))
                    CreateRegisterCommand(parts);
                else
                    CreateMoveCommand(parts);
            }
        }

        private void CreateRegisterCommand(string[] parts)
        {
            Name = "Register";
            param = new List<string>();
            foreach (var part in parts)
                param.Add(part);
        }

        private void CreateMoveCommand(string[] parts)
        {
            Name = "Move";
            param = new List<string>();
            foreach (var part in parts)
                param.Add(part);
        }

        private void CreateExitCommand()
        {
            Name = "Exit";
        }
    }
}
