Feature: SpecGame
	In order to have some fun
	As a game junkie
	I want to have rules checked when playing Tic-Tac-Toe

@mytag
Scenario: New game begins
	Given New game starts
	Then player to move is "Circle"
	And play mode is "Playing"

Scenario: Circle makes first move
	Given New game starts
	When Player makes move
		| Player | Line  | Column  |
		| Circle | A     | One     |
	Then  player to move is "Cross"
	And play mode is "Playing"

Scenario: Circle makes invalid third move
	Given New game starts
	When Players play moves
		| Player | Line  | Column  | 
		| Circle | A     | One     |
        | Cross  | A     | Three   |
		| Circle | A     | One     |
	Then  player to move is "Circle"
	And play mode is "Playing"

Scenario: Circle wins game in columns
	Given New game starts
	When Players play moves
		| Player | Line  | Column  | 
		| Circle | A     | One     |
        | Cross  | A     | Three   |
		| Circle | B     | One     |
		| Cross  | B     | Three   |
		| Circle | C     | One     |
	Then  play mode is "CircleWon"

Scenario: Cross wins game in rows
	Given New game starts
	When Players play moves
		| Player | Line  | Column  | 
		| Circle | A     | One     |
        | Cross  | B     | One	   |
		| Circle | A     | Two     |
		| Cross  | B     | Two	   |
		| Circle | C     | One     |
		| Cross  | B     | Three   |
	Then  play mode is "CrossWon"

Scenario: Cross wins game in contra diagonal
	Given New game starts
	When Players play moves
		| Player | Line | Column |
		| Circle | A    | One    |
		| Cross  | A    | Three  |
		| Circle | A    | Two    |
		| Cross  | B    | Two    |
		| Circle | C    | Three  |
		| Cross  | C    | One    |
	Then  play mode is "CrossWon"

Scenario: Circle wins game in diagonal and no move is possible after win
	Given New game starts
	When Players play moves
		| Player | Line | Column |
		| Circle | A    | One    |
		| Cross  | A    | Three  |
		| Circle | B    | Two    |
		| Cross  | B    | Three  |
		| Circle | C    | Three  |
	Then  play mode is "CircleWon"
	When Player makes move
		| Player | Line  | Column  |
		| Circle | A     | One     |
	Then  play mode is "CircleWon"

Scenario: Game is drawn and no move is possible after draw
	Given New game starts
	When Players play moves
		| Player | Line  | Column  | 
		| Circle | A     | One     |
        | Cross  | A     | Three   |
		| Circle | B     | One     |
		| Cross  | B     | Three   |
		| Circle | C     | Three   |
		| Cross  | C     | One     |
		| Circle | C     | Two     |
		| Cross  | B     | One     |
		| Circle | B     | Two     |
	Then play mode is "Draw"
	When Player makes move
		| Player | Line  | Column  |
		| Circle | A     | One     |
	Then  play mode is "Draw"





	