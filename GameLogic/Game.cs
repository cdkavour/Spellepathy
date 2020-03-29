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
		Random RNG = new Random();
		int rand = RNG.Next(1,10);
		bool isVowel = (rand > 6);
		return isVowel;
	}
}