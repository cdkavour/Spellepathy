using System;

public class Team {
	// Team Player Array

	// Team ID
	public int teamID;

	// Play Space
	public string playspace;

	// Score
	public int score;

	// Phase
	public int phase;

	// Skips
	public int skips;

	public Team(int teamID) {
		this.teamID = teamID;
		playspace = "*?*";
		score = 0;
		phase = 1;
		skips = 0;
	}

	public void PrintTeam() {
		Console.WriteLine("TeamID: {0}", teamID);
		Console.WriteLine("Playspace: {0}", playspace);
		Console.WriteLine("Score: {0}", score);
		Console.WriteLine("Phase: {0}", phase);
		Console.WriteLine("Skips: {0}\n", skips);
	}
}