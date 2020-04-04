using System;
using System.Collections.Generic;

public class Player {
	// Letter Hand
	Dictionary<char, int> letterHand;

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

		letterHand = new Dictionary<char, int>();
		for (int chr = 97; chr < 123; chr++) {
			letterHand.Add((char)chr, 0);
		}
		letterHand.Add('?', 0);
	}

	// Draw Letter
	public void DrawLetter() {
		char letter = Helper.GetNextLetter();
		letterHand[letter] += 1;

		Console.WriteLine("Player {0} drew letter {1}.", playerID, letter);
		Console.WriteLine("Player {0} updated letter hand: {1}", playerID, letterHand);
	}

	public void PrintPlayer() {
		Console.WriteLine("Player ID: {0}, Team ID: {1}", playerID, teamID);
		Console.Write("Partner IDs: ");
		for (int j = 0; j < partnerIDs.Length; j++) {
			Console.Write("{0}, ", partnerIDs[j]);
		}
		Console.Write("\n");

		// Print Letter Hand
		foreach(KeyValuePair<char, int> kvp in letterHand) { 
            Console.WriteLine("Letter: {0}, Count: {1}", kvp.Key, kvp.Value); 
        }
		Console.WriteLine("\n");
	}
}
