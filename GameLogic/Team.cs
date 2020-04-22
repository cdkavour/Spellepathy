using System;

public class Team {
	// Team Player Array

	// Team ID
	public int teamID;

	// Play Space
	public char[][] playspaces;

	// Score
	public int score;

	// Phase
	public int phase;

	// Skips
	public int skips;

	public Team(int teamID) {
		this.teamID = teamID;
		playspaces = PlayPhases.GenPlayspaces();
		score = 0;
		phase = 0;
		skips = 0;
	}

	public void RestartPhase() {
		for(int i = 0; i < playspaces[phase].Length; i++) {
			if (i == PlayPhases.unknownIndexes[phase]) {
				playspaces[phase][i] = '?';
			}
			else {
				playspaces[phase][i] = '*';
			}
		}

		Console.WriteLine("\nPhase Restarted.");
		PrintPlayspace();
	}

	// Returns true if game is over
	public bool GoNextPhase() {
		phase++;
		return (phase >= 5);
	}

	public void PrintPlayspace() {
		Console.Write("\nPlayspace: ");
		foreach (char c in playspaces[phase]) {
			Console.Write(c);
		}
		Console.WriteLine("\n");
	}

	public void PrintTeam() {
		Console.WriteLine("\nTeamID: {0}", teamID);
		PrintPlayspace();
		Console.WriteLine("Score: {0}", score);
		Console.WriteLine("Phase: {0}", phase);
		Console.WriteLine("Skips: {0}\n", skips);
	}
}