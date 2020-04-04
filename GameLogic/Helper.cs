using System;

public static class Globals {
	public static Random vowelRNG = new Random();
	public static Random letterRNG = new Random();
}

public class Helper {

	public static bool NextIsVowel() {
		return (Globals.vowelRNG.NextDouble() > 0.64);
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
			throw new System.IndexOutOfRangeException("Invalid Next Letter Index {0}, must be between 1-128 inclusive.");
		}

		return nextLetter;
	}
}
