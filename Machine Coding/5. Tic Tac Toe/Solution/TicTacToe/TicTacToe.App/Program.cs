using TicTacToe.App.Src;
using TicTacToe.App.Src.Enums;
using TicTacToe.App.Src.Utilities;

Console.WriteLine("Welcome to Tic Tac Toe game.");

string gameBoardSize = ConfigReader.Instance.GetValue("GameBoardSize");
int boardSize = string.IsNullOrEmpty(gameBoardSize) ? 0 : Convert.ToInt32(gameBoardSize);

const InputMode inputMode= InputMode.File;

GameStation gameStation = new GameStation(inputMode, boardSize);
gameStation.Play();

if(inputMode == InputMode.File)
    Console.WriteLine($"Please check input/output here: \n {DirectoryHelper.GetCurrentDirectory()}{ConfigReader.Instance.GetValue("FileMode:Folder")}");