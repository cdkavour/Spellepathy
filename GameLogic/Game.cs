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
		nextIsVowel = Helper.NextIsVowel();

		// Initialize Players
		players = new Player[numPlayers];
		for (int i = 0; i < numPlayers; i++) {
			players[i] = new Player(i, numPlayers, numTeams);
			players[i].PrintPlayer();
		}

		// Initialize Teams
		teams = new Team[numTeams];
		for (int i = 0; i < numTeams; i++) {
			teams[i] = new Team(i);
			// teams[i].PrintTeam();
		}
	}

	public void TakeTurn(Player p, Team t) {
		Console.WriteLine("Player Turn: {0}, Team Turn: {1} == {2}\n", p.playerID, p.teamID, t.teamID);
		p.DrawLetter();
	}

	public void PlayGame() {

		while (playerTurn < 3) {
			int teamTurn = players[playerTurn].teamID;
			TakeTurn(players[playerTurn], teams[teamTurn]);


			playerTurn++;
		}
	}
}
