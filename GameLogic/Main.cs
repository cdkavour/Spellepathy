using System;

public class Driver {
	// Parameters
	public int NUM_PLAYERS = 4;
	public int NUM_TEAMS = 2;

	public void Run() {
		Console.WriteLine("\n\n#############################################");
		Console.WriteLine("########## START SPELLEPATHY GAME ###########");
		Console.WriteLine("#############################################\n\n");

		// Initialize Game
		Game game = new Game(NUM_PLAYERS, NUM_TEAMS);
		game.PlayGame();

		// Play Game
		Console.WriteLine("#############################################");
		Console.WriteLine("########### END SPELLEPATHY GAME ############");
		Console.WriteLine("#############################################\n\n");
	}
}

public class Spellepathy {
	public static void Main() {
		Driver driver = new Driver();
		driver.Run();
	}
}