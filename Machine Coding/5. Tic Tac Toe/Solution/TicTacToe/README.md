# Solution - Tic Tac Toe

.Net 6 Console App

## Steps:

> Open the solution TicTacToe.sln

> Run

    There is 1 input mode:
        File (default)
* Size of Game Board can be changed from appSettings.json

## Input:
> In File mode:

    System can read the listed commands from a InputFile.txt
    
    A sample file is present under IO.
    
    Note: File name & location is configurable thru appSettings.json 
          Only .txt file is allowed.

> use 'exit' command at the last to end the system process

## Output:
> In File mode:

    System prints result for each command in a OutputFile.txt
    
    A sample file is present under IO.
    
    Note: File name & location are configurable thru appSettings.json 
          Only .txt file is allowed.


## Example:
### Sample Input Commands:

    X Gaurav
    O Sagar
    2 2
    1 3
    1 1
    1 2
    2 2
    3 3
    exit


### Expected Output:

    - - - 
    - - - 
    - - - 
    - - - 
    - X - 
    - - - 
    - - O 
    - X - 
    - - - 
    X - O 
    - X - 
    - - - 
    X O O 
    - X - 
    - - - 
    Invalid Move 
    X O O 
    - X - 
    - - X 
    Gaurav won the game 
    Game Over
  
### Sample Input Commands:

    X Gaurav
    O Sagar
    2 3
    1 2
    2 2
    2 1
    1 1
    3 3
    3 2
    3 1
    1 3
    exit


### Expected Output:

    - - - 
    - - - 
    - - - 
    - - - 
    - - X 
    - - - 
    - O - 
    - - X 
    - - - 
    - O - 
    - X X 
    - - - 
    - O - 
    O X X 
    - - - 
    X O - 
    O X X 
    - - - 
    X O - 
    O X X 
    - - O 
    X O - 
    O X X 
    - X O 
    X O - 
    O X X 
    O X O 
    X O X 
    O X X 
    O X O 
    Game Over
  
