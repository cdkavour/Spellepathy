using System;
using System.Linq;
using System.Collections.Generic;

public class Player {
	// Letter Hand
	public Dictionary<char, int> letterHand;

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

		Console.WriteLine("\nPlayer {0} drew letter {1}.\n", playerID, letter);
		PrintLetterHand();
	}

	// Discard Letter
	public void DiscardLetter() {
		char userChar;
		while (true) {
			Console.WriteLine("\nEnter a Letter to Discard:");
			userChar = Console.ReadKey().KeyChar;
			Console.WriteLine("\nYou Entered: {0}", userChar);
			if (!letterHand.ContainsKey(userChar)) {
				Console.WriteLine("\nCharacter {0} is not a valid letter card.", userChar);
			}
			else if (letterHand[userChar] <= 0) {
				Console.WriteLine("\nYou do not have any {0} in you hand.");
			}
			else {
				break;
			}
		}

		Console.WriteLine("\nDiscarding Letter {0}.", userChar);
		letterHand[userChar]--;
	}

	// Play Letter (returns true if game is over)
	public bool PlayLetter(Team t) {
		// Enter Letter to Play
		char userChar;

		// Check User Letter is Valid
		while (true) {
			Console.WriteLine("\nEnter a Letter to Play:");
			userChar = Console.ReadKey().KeyChar;
			Console.WriteLine("\nYou Entered: {0}", userChar);
			if (!letterHand.ContainsKey(userChar)) {
				Console.WriteLine("\nCharacter {0} is not a valid letter card.", userChar);
			}
			else if (letterHand[userChar] <= 0) {
				Console.WriteLine("\nYou do not have any {0} in you hand.", userChar);
			}
			else {
				break;
			}
		}

		// Choose play space to place letter on
		int userSpot;
		while(true) {
			Console.WriteLine("\nEnter the spot you would like to place your letter.\nAvailable spots: ");
			for (int i = 0; i < t.playspaces[t.phase].Length; i++) {
				if (t.playspaces[t.phase][i] == '*') {
					Console.Write("{0}, ", i+1);
				}
			}
			Console.Write("\n");

			// Read User Input
			try {
				userSpot = Convert.ToInt32(Console.ReadLine());
				userSpot--;

				// Check user input
				if (userSpot < 0 || userSpot >= t.playspaces[t.phase].Length) {
					Console.WriteLine("\nInteger {0} is not a valid spot in your playspace. Please enter a valid spot.", userSpot);
				}
				else if (t.playspaces[t.phase][userSpot] != '*') {
					Console.WriteLine("\nInteger {0} is not a valid spot in your playspace (already contains letter {1}). Please enter a valid spot.", userSpot, t.playspaces[t.phase][userSpot]);	
				}
				else {
					break;
				}
			}
			catch(Exception ex) {
				Console.WriteLine("Error: " + ex.ToString());
			}
		}

		// Check for Wild Card
		char wildChar;
		if (userChar == '?') {
			while (true) {
				Console.WriteLine("\nWhat letter would you like to play with this WILD CARD?");
				wildChar = Console.ReadKey().KeyChar;
				if (!letterHand.ContainsKey(wildChar)) {
					Console.WriteLine("\nCharacter {0} is not a valid letter card. Please choose a letter a-z.", userChar);
				}
				else if (wildChar == '?') {
					Console.WriteLine("\nCannot substitue a WILD CARD with /'?/'. Please choose a letter a-z.");
				}
				else {
					Console.WriteLine("\nYou Entered: {0}", wildChar);
					t.playspaces[t.phase][userSpot] = wildChar;
					break;
				}
			}
		}
		else {
			t.playspaces[t.phase][userSpot] = userChar;
		}

		Console.WriteLine("\nPlayed Letter {0}!", userChar);
		t.PrintPlayspace();

		// Discard letter from hand
		letterHand[userChar]--;

		// Check if word is complete, Restart phase as necessary
		bool gameover = false;
		if (!t.playspaces[t.phase].Contains('*')) {
			// TODO - Flip Question Mark, Check Word, and Restart Phase if necessary
			// If team phase is 3 (technically 2), no ? to flip
			// If team phase is 1 or 4 (technically 0 or 3), get a new vowel
			// If team phase is 2 or 5 (technically 1 or 4), get a new consonant

			char unknownVowel = Helper.GetNextVowel();
			char unknownConsonant = Helper.GetNextConsonant();
			if (t.phase == 0) {
				Console.WriteLine("\n All phase 1 letters are set. Flipping unknown vowel .... It's {0}!", unknownVowel);
				t.playspaces[t.phase][1] = unknownVowel;
			}
			else if(t.phase == 1) {
				Console.WriteLine("\n All phase 2 letters are set. Flipping unknown consonant .... It's {0}!", unknownConsonant);
				t.playspaces[t.phase][3] = unknownConsonant;
			}
			else if(t.phase == 2) {
				Console.WriteLine("\n All phase 3 letters are set. No unknown to flip.");
			}
			else if(t.phase == 3) {
				Console.WriteLine("\n All phase 4 letters are set. Flipping unknown vowel .... It's {0}!", unknownVowel);
				t.playspaces[t.phase][1] = unknownVowel;
			}
			else if(t.phase == 4) {
				Console.WriteLine("\n All phase 5 letters are set. Flipping unknown consonant .... It's {0}!", unknownConsonant);
				t.playspaces[t.phase][0] = unknownConsonant;
			}

			string finalWord = new string(t.playspaces[t.phase]);
			Console.WriteLine("\nYou spelled: {0}", finalWord);
			if (Helper.IsValidScrabbleWord(finalWord)) {
				Console.WriteLine("\nWord complete! Phase {0} complete! On to Phase {1}:", t.phase+1, t.phase+2);
				gameover = t.GoNextPhase();
				t.PrintPlayspace();
			}
			else {
				Console.WriteLine("\nSorry! {0} is not a valid word. Restarting phase {1}", finalWord, t.phase);
				t.RestartPhase();
			}
		}

		// Returns true if game is over
		return gameover;
	}

	public bool HandIsEmpty() {
		foreach(KeyValuePair<char, int> kvp in letterHand) { 
			if (kvp.Value != 0) {
				return false;
			}
        }
        return true;
	}

	public void PrintLetterHand() {
		Console.WriteLine("Letter Hand:");
		if(HandIsEmpty()) {
			Console.WriteLine(" Empty.");
		}
		else {
			foreach(KeyValuePair<char, int> kvp in letterHand) { 
				if (kvp.Value != 0) {
					Console.WriteLine("Letter: {0}, Count: {1}", kvp.Key, kvp.Value); 
				}
	        }
		}
        Console.Write("\n");
	}

	public void PrintPlayer() {
		Console.WriteLine("\nPlayer ID: {0}, Team ID: {1}", playerID, teamID);
		Console.Write("\nPartner IDs: ");
		for (int j = 0; j < partnerIDs.Length; j++) {
			Console.Write("{0}, ", partnerIDs[j]);
		}
		Console.Write("\n");

		PrintLetterHand();
	}
}
