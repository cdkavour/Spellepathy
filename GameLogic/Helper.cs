using System;
using System.IO;

public static class Globals {
	public static Random vowelRNG = new Random();
	public static Random consonantRNG = new Random();
	public static Random letterRNG = new Random();
}

public static class PlayPhases {
	public static char[][] GenPlayspaces() {
		char[][] playspaces = new char[][]{
			new char[] {'*', '?', '*'},
			new char[] {'*', '*', '*', '?'},
			new char[] {'*','*','*','*','*'},
			new char[] {'*','?','*','*'},
			new char[] {'?','*','*','*','*'},
			new char[] {'$'}
		};

		return playspaces;
	}

	public static int[] unknownIndexes = new int[]{1, 3, -1, 1, 0};
}

public class Helper {
	public static void AutoPopulateHands(Player[] players) {
		foreach(Player player in players) {
			for(int i = 0; i < 20; i++) {
				char letter = GetNextLetter();
				player.letterHand[letter] += 1;
			}
		}
	}

	public static bool IsValidScrabbleWord(string word) {
		Console.WriteLine("\nChecking if {0} is a valid word ...", word);

		if(File.ReadAllText("dictionary.json").Contains(word)) {
			Console.WriteLine("Word found! :)");
    		return true;
		}

		Console.WriteLine("Word not found. :(");
		return false;
	}

	public static bool NextIsVowel() {
		return (Globals.vowelRNG.NextDouble() > 0.64);
	}	

	public static char GetNextVowel() {
		int nextVowelIndex = Globals.vowelRNG.Next(1, 46);
		char nextVowel = '*';

		if(nextVowelIndex <= 10) {
			nextVowel = 'a';
		}
		else if(nextVowelIndex <= 24) {
			nextVowel = 'e';
		}
		else if(nextVowelIndex <= 32) {
			nextVowel = 'i';
		}
		else if(nextVowelIndex <= 41) {
			nextVowel = 'o';
		}
		else if(nextVowelIndex <= 45) {
			nextVowel = 'u';
		}
		else {
			throw new System.IndexOutOfRangeException("Invalid Next Vowel Index, must be between 1-45 inclusive.");
		}

		return nextVowel;
	}

	public static char GetNextConsonant() {
		int nextConsonantIndex = Globals.consonantRNG.Next(1, 81);
		char nextConsonant = '*';

		if(nextConsonantIndex <= 5) {
			nextConsonant = 'b';
		}
		else if(nextConsonantIndex <= 9) {
			nextConsonant = 'c';
		}
		else if(nextConsonantIndex <= 13) {
			nextConsonant = 'd';
		}
		else if(nextConsonantIndex <= 16) {
			nextConsonant = 'f';
		}
		else if(nextConsonantIndex <= 21) {
			nextConsonant = 'g';
		}
		else if(nextConsonantIndex <= 24) {
			nextConsonant = 'h';
		}
		else if(nextConsonantIndex <= 25) {
			nextConsonant = 'j';
		}

		else if(nextConsonantIndex <= 26) {
			nextConsonant = 'k';
		}
		else if(nextConsonantIndex <= 32) {
			nextConsonant = 'l';
		}
		else if(nextConsonantIndex <= 35) {
			nextConsonant = 'm';
		}
		else if(nextConsonantIndex <= 41) {
			nextConsonant = 'n';
		}
		else if(nextConsonantIndex <= 45) {
			nextConsonant = 'p';
		}
		else if(nextConsonantIndex <= 48) {
			nextConsonant = 'q';
		}
		else if(nextConsonantIndex <= 54) {
			nextConsonant = 'r';
		}
		else if(nextConsonantIndex <= 62) {
			nextConsonant = 's';
		}
		else if(nextConsonantIndex <= 68) {
			nextConsonant = 't';
		}
		else if(nextConsonantIndex <= 70) {
			nextConsonant = 'v';
		}
		else if(nextConsonantIndex <= 72) {
			nextConsonant = 'w';
		}
		else if(nextConsonantIndex <= 75) {
			nextConsonant = 'x';
		}
		else if(nextConsonantIndex <= 77) {
			nextConsonant = 'y';
		}
		else if(nextConsonantIndex <= 80) {
			nextConsonant = 'z';
		}
		else {
			throw new System.IndexOutOfRangeException("Invalid Next Consonant Index, must be between 1-80 inclusive.");
		}
		return nextConsonant;
	}

	public static char GetNextLetter() {
		int nextLetterIndex = Globals.letterRNG.Next(1, 129);
		char nextLetter = '*';

		if(nextLetterIndex <= 10) {
			nextLetter = 'a';
		}
		else if(nextLetterIndex <= 15) {
			nextLetter = 'b';
		}
		else if(nextLetterIndex <= 19) {
			nextLetter = 'c';
		}
		else if(nextLetterIndex <= 23) {
			nextLetter = 'd';
		}
		else if(nextLetterIndex <= 37) {
			nextLetter = 'e';
		}
		else if(nextLetterIndex <= 40) {
			nextLetter = 'f';
		}
		else if(nextLetterIndex <= 45) {
			nextLetter = 'g';
		}
		else if(nextLetterIndex <= 48) {
			nextLetter = 'h';
		}
		else if(nextLetterIndex <= 56) {
			nextLetter = 'i';
		}
		else if(nextLetterIndex <= 57) {
			nextLetter = 'j';
		}

		else if(nextLetterIndex <= 58) {
			nextLetter = 'k';
		}
		else if(nextLetterIndex <= 64) {
			nextLetter = 'l';
		}
		else if(nextLetterIndex <= 67) {
			nextLetter = 'm';
		}
		else if(nextLetterIndex <= 73) {
			nextLetter = 'n';
		}
		else if(nextLetterIndex <= 82) {
			nextLetter = 'o';
		}
		else if(nextLetterIndex <= 86) {
			nextLetter = 'p';
		}
		else if(nextLetterIndex <= 89) {
			nextLetter = 'q';
		}
		else if(nextLetterIndex <= 95) {
			nextLetter = 'r';
		}
		else if(nextLetterIndex <= 103) {
			nextLetter = 's';
		}
		else if(nextLetterIndex <= 109) {
			nextLetter = 't';
		}

		else if(nextLetterIndex <= 113) {
			nextLetter = 'u';
		}
		else if(nextLetterIndex <= 115) {
			nextLetter = 'v';
		}
		else if(nextLetterIndex <= 117) {
			nextLetter = 'w';
		}
		else if(nextLetterIndex <= 120) {
			nextLetter = 'x';
		}
		else if(nextLetterIndex <= 122) {
			nextLetter = 'y';
		}
		else if(nextLetterIndex <= 125) {
			nextLetter = 'z';
		}

		else if(nextLetterIndex <= 128) {
			nextLetter = '?';
		}

		else {
			throw new System.IndexOutOfRangeException("Invalid Next Letter Index, must be between 1-128 inclusive.");
		}

		return nextLetter;
	}
}
