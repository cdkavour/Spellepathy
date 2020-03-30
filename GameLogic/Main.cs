using System;

public class Driver {
	// Parameters
	public int NUM_PLAYERS = 4;
	public int NUM_TEAMS = 2;

	public void Run() {
		Console.WriteLine("Start Spellepathy Game.");

		// Initialize Game
		Game game = new Game(NUM_PLAYERS, NUM_TEAMS);
		game.PlayGame();

		// Play Game
		Console.WriteLine("End Spellepathy Game.");
	}
}

public class Spellepathy {
	public static void Main() {
		Driver driver = new Driver();
		driver.Run();
	}
}