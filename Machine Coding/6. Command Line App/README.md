# Command line App:

Print numbers from 1 - n

## Requirements

Create a command-line application with the following requirements:

1. User can provide input thru command line
2. Print the number from 1 - n
    * If number is divisible by 3 then print 2nd command line argument if provided else print "fizz" 
    * If number is divisible by 5 then print 3nd command line argument if provided else print "buzz" 
	* If number is divisible by 3 and 5 both then print 2nd & 3rd command line arguments inline if provided else print "fizz buzz"
	* Print "Invalid Input" if wrong command line argument has passed
 

## Input/Output Format
The code should strictly follow the input/output format and will be tested with provided test cases.

### Input Format
Optional input can only provided thru command line

* 1st command line argument should be a number (n)
* 2nd command line argument should be a string (to print when number is divisible by 3)
* 3rd command line argument should be a string (to print when number is divisible by 5)

### Output Format
Print the numbers 1 - n:

* If number is divisible by 3 then print 2nd command line argument or "fizz" by default

* If number is divisible by 5 then print 3rd command line argument or "buzz" by default

* If number is divisible by 3 and 5 both then print 2nd & 3rd command line arguments inline or "fizz buzz" by default

* Print Invalid Input if wrong command line argument has passed

### Examples

#### Sample Input

	15 foo bar


#### Expected Output

	1
	2
	foo
	4
	bar
	foo
	7
	8
	foo
	bar
	11
	foo
	13
	14
	foo bar


### Expectations
	1. Make sure that you have a working and demonstrable code
	
	2. Make sure that the code is functionally correct
	
	3. Code should be modular and readable
	
	4. Separation of concern should be addressed
	
	5. Please do not write everything in a single file
	
	6. Code should easily accommodate new requirements and minimal changes
	
	7. There should be a main method from where the code could be easily testable
	
	8. Write unit tests, if possible
	
	9. No need to create a GUI
	

