using System;

public class Game {
	// Team Array
	public Team[] teams;

	// Player Array
	public Player[] players;

	// Number of Players
	public int numPlayers;

	// Number of Teams
	public int numTeams;

	// Turn Counter
	public int playerTurn;

	// Next Is Vowel
	public bool nextIsVowel;

	// Game Over
	public bool gameOver;

	// Constructor
	public Game(int numPlayers, int numTeams) {
		this.numPlayers = numPlayers;
		this.numTeams = numTeams;
		gameOver = false;
		playerTurn = 0;
		nextIsVowel = NextIsVowel();

		int playersPerTeam = numPlayers / numTeams;

		// Initialize Players
		players = new Player[numPlayers];
		for (int i = 0; i < numPlayers; i++) {
			players[i] = new Player(i, numPlayers, numTeams);
		}

		// Initialize Teams
		teams = new Team[numTeams];
		for (int i = 0; i < numTeams; i++) {
			teams[i] = new Team(i);
			teams[i].PrintTeam();
		}
	}

	public void PlayGame() {

		while (!gameOver) {
			Console.WriteLine("Player {0}'s Turn.", playerTurn);
			


			gameOver = true;
		}
	}

	public bool NextIsVowel() {
		return (new Random().NextDouble() > 0.64);
	}
}
