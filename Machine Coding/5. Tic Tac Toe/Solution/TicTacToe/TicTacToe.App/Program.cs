using TicTacToe.App.Src;
using TicTacToe.App.Src.enums;

Console.WriteLine("Welcome to Tic Tac Toe game.");

const int boardSize = 3;
const InputMode inputMode= InputMode.File;

GameStation gameStation = new GameStation(inputMode, boardSize);
gameStation.Play();