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

	// Number total turns
	public int currentTurn;

	// Next Is Vowel
	public bool nextIsVowel;

	// Game Over
	public bool gameover;

	// Constructor
	public Game(int numPlayers, int numTeams) {
		this.numPlayers = numPlayers;
		this.numTeams = numTeams;
		gameover = false;
		playerTurn = 0;
		currentTurn = 0;
		nextIsVowel = Helper.NextIsVowel();

		// Initialize Players
		players = new Player[numPlayers];
		for (int i = 0; i < numPlayers; i++) {
			players[i] = new Player(i, numPlayers, numTeams);
			//players[i].PrintPlayer();
		}

		// Initialize Teams
		teams = new Team[numTeams];
		for (int i = 0; i < numTeams; i++) {
			teams[i] = new Team(i);
			//teams[i].PrintTeam();
		}

		// Hand out cards to the players
		Helper.AutoPopulateHands(players);
	}

	public void TakeTurn(Player p, Team t) {
		Console.WriteLine("Player {0}'s Turn (Team {1})\n", p.playerID+1, p.teamID+1);
		//Console.WriteLine("On Team: {0} == {1}", p.teamID+1, t.teamID+1);
		p.PrintLetterHand();
		t.PrintPlayspace();

		// Read user's choice of action: draw, discard, or play
		// Persist on user until valid action is input
		Console.WriteLine("Choose Your Action! (type draw, play, or discard):");
		string userAction;
		while(true) {
			userAction = Console.ReadLine();
			if (userAction == "draw") {
				p.DrawLetter();
				break;
			}
			else if (userAction == "play") {
				if (p.HandIsEmpty()) {
					Console.WriteLine("\nYou have no letters in your hand to play. Please choose a different action.");
				}
				else {
					gameover = p.PlayLetter(t);
					break;
				}
			}
			else if (userAction == "discard") {
				if (p.HandIsEmpty()) {
					Console.WriteLine("\nYou have no letters in your hand to discard. Please choose a different action.");
				}
				else {
					p.DiscardLetter();
					break;
				}
			}
			else {
				Console.WriteLine("\nUnknown Action - please enter 'draw', 'play', or 'discard'.");
			}
		}
	}

	public void PlayGame() {

		while (!gameover) {
			Console.WriteLine("################## TURN {0} ##################\n", currentTurn+1);
			int teamTurn = players[playerTurn].teamID;
			TakeTurn(players[playerTurn], teams[teamTurn]);
			if (gameover) {
				Console.WriteLine("Team {0} has completed all phases of the game! Team {0} wins!\n\n Game Over.\n\n", teamTurn+1);
				//break;
			}

			playerTurn = (playerTurn == 3) ? playerTurn = 0 : playerTurn + 1;
			currentTurn++;
		}
	}

	public void PrintPlayers() {
		foreach (Player p in players) {
			p.PrintPlayer();
		}
	}

	public void PrintTeams() {
		Console.WriteLine("Number of Teams: {0}", teams.Length);
		for (int i = 0; i < teams.Length; i++) {
			teams[i].PrintTeam();
		}
	}
}
