# Tic-Tac-Toe


## Requirements:

- Two human players take turns entering their choice using the same keyboard
- The players designate which square they want to play in
	- Maybe use the numpad as a guide, 9 fields, nine digits
	- Also maybe the wasd and arrow keys, but two distinct colors for the players
		- Red and Yellow?
- The game should prevent players from choosing squares that are already occupied.
	- Tell the player it's not possible and give them another chance.
- The game must detect when a player wins or when the board is full with no winner
- Whe the game is over, the outcome is displayed to the players.
- The state of the board must be displayed to the player after each play.

### What exists here? And what does it do?

- players
	- they can have a name, but X, O is default
	- add points if we want to play more rounds than one
	- maybe add a boolean for being already chosen
		- if the player is going ahead and chooses O first. 
- the game board
	- draws the board
	- colors the player's choices
	- displays state of the game
- the logic or the state of the game
	- deals with the main menu handling the players
		- 1 round
		- 3 rounds
		- 5 rounds
		- exit
		- which player wants to play as what (own char's? WHACKKY)
	- handles control
		- numpad choice, numbers 1-9
		- WASD and Arrow keys
		- Try to implement mouse control (at the end)
	- handles game logic
		- check if field is already taken
		- check if game is draw
		- check where the players put their signs
		- handles points if we play more rounds
		- gives an overhead of the field to the drawing board.
			- what are the players' chars?
			- which fields belong to whom?
			- points if it's longer than a round
		

### where is the logic?

- Game starts and presents menu -> It's console stuff, but should be handled by the logic
- User chooses -> logic handles how the player's should be utilized and set's a maxscore value
- Logic starts by sending the necessary player and game stats to Gameboard
- Gameboard draws or renders the necessary information for players to see
- Logic interjects and gets player input from Player 1
- checks if the field the player choose has any of the player's chars and acts on it or warns the player
- handles it and changes state and sends updated information to gameboard again.
- asks again for infos bla bla bla, we have three classes .