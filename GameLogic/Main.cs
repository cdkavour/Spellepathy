using System;

public class Driver {

	public static void Main() {
		Console.WriteLine("Start Spellepathy Game.");

		// Initialize Game
		Game game = new Game();
		Console.WriteLine("Game Player Turn: {0}", game.playerTurn);
		Console.WriteLine("Game Next is Vowel: {0}", game.nextIsVowel);

		// Play Game

		Console.WriteLine("End Spellepathy Game.");
	}
}