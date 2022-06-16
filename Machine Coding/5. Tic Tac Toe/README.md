# Problem - Tic Tac Toe:

https://workat.tech/machine-coding/practice/design-tic-tac-toe-smyfi9x064ry

Let's look at the game of Tic Tac Toe. It is a two-player strategy game played on a 3*3 grid. There are 9 empty cells and 9 pieces - 5 pieces of 'X' and 4 pieces of 'O'.

The game starts with an empty grid.

![image](https://user-images.githubusercontent.com/36097146/174100188-fc00a549-058f-4de5-832e-f91aa863f275.png)


### Game Rules:
* The game is played between two players. One player owns the X pieces and can put it on any of the empty cells in the grid. The other player owns the O pieces and can in any of the empty cells.
* The player with X makes the first turn. Each player plays alternately after that.
* The first player to form a horizontal/vertical/diagonal sequence wins.

## Requirements

Create a command-line application for tic tac toe with the following requirements:

1. Ask the user for the names of the two players
2. Print the grid after initializing
3. Allow the user to make moves on behalf of both the players.
    * The user will make a move by entering the cell position.
    * You need to determine the piece (X/O) and make the move if it is valid.
    * Valid move:
        * The piece is controlled by the player having the current turn
        *  The cell is empty
    * If the move is invalid
        * print 'Invalid Move'
        * the same player plays again
    * If the move is valid:
        * put the piece on the cell
        * print the board after the move
4. Determine if a player has won or if there are no valid moves left. Ignore all moves mentioned after that.

A position in the cell is represented by two values: row number (1-3) and column number (1-3).

### Examples
* 3 1 represents the cell at the extreme bottom-left (3rd row, 1st column)
* 1 3 represents the cell at the extreme top-right (1st row, 3rd column)

## Input/Output Format
The code should strictly follow the input/output format and will be tested with provided test cases.

### Input Format
Multiple lines with each line containing the Cell Position. The row and column numbers will be separated by a space.

Stop taking the input when you encounter the word exit.

### Output Format
Print the initial grid. This would be followed by the grid after each move. In case of an invalid move, do not print the grid and instead print:

Invalid Move

The board needs to be printed in the following format based on the respective position:

    X X O
    - - X
    O O -
  
Here,

X and O represent the different pieces. An empty cell is represented by a hyphen (-).

The initial position of the board would be

    - - -
    - - -
    - - -
    
If the player wins after a move, print: 'Player_Name won the game'

If there are no valid moves left for any player, print 'Game Over'

### Examples
#### Sample Input

	X Gaurav
    O Sagar
    2 2
    1 3
    1 1
    1 2
    2 2
    3 3
    exit


#### Expected Output

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


#### Sample Input

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


#### Expected Output

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
    X O X
    O X X
    O X O
    Game Over


#### Sample Input

	X Gaurav
    O Sagar
    exit


#### Expected Output

	- - -
    - - -
    - - -


### Expectations
	1. Make sure that you have a working and demonstrable code
	
	2. Make sure that the code is functionally correct
	
	3. Code should be modular and readable
	
	4. Separation of concern should be addressed
	
	5. Please do not write everything in a single file
	
	6. Code should easily accommodate new requirements and minimal changes
	
	7. There should be a main method from where the code could be easily testable
	
	8. [Optional] Write unit tests, if possible
	
	9. No need to create a GUI
	
### Optional Requirements
Write your code such that these could be accommodated without changing your code much.

	1. Keep the code extensible to change the size of the grid.
	
	2. Keep the code extensible to allow different types of pieces.
	
	3. Keep the code extensible to allow more than 2 players/piece types.

