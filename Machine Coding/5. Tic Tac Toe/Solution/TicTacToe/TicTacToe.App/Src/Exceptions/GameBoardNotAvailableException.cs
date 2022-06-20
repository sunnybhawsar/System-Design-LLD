using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.App.Src.Exceptions
{
    internal class GameBoardNotAvailableException : Exception
    {
        public GameBoardNotAvailableException(string message = "Game board not available") : base(message) 
        {
        }
    }
}
