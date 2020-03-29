using System;

public class Game {
	// Team Array
	// Player Array

	// Turn Counter
	public int playerTurn;

	// Next Is Vowel
	public bool nextIsVowel;

	// Constructor
	public Game() {
		playerTurn = 0;
		nextIsVowel = NextIsVowel();
	}

	public bool NextIsVowel() {
		return (new Random().NextDouble() > 0.64);
	}
}