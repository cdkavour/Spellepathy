using System;

public class Player {
	// Letter Hand
	// Impactor Hand

	// Player ID
	public int playerID;

	// Parter ID
	public int[] partnerIDs;

	// Team ID
	public int teamID;

	public Player(int playerID, int numPlayers, int numTeams) {
		this.playerID = playerID;

		int playersPerTeam = (numPlayers / numTeams);
		this.teamID = playerID % playersPerTeam;
		this.partnerIDs = new int[playersPerTeam];

		int count = teamID;
		for (int i = 0; i < playersPerTeam; i++) {
			partnerIDs[i] = count;
			count = count + playersPerTeam;
		}
	}

	public void PrintPlayer() {
		Console.WriteLine("Player ID: {0}, Team ID: {1}", playerID, teamID);
		Console.Write("Partner IDs:");
		for (int j = 0; j < partnerIDs.Length; j++) {
			Console.Write("{0}, ", partnerIDs[j]);
		}
		Console.Write("\n");
	}
}
