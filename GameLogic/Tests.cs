using System;

public class Tests {
	public static void Main() {
		string[] words = new string[] {
			"hello",
			"asdfghk",
			"book",
			"wonderfully",
			"cxcxc"
		};		

		foreach(string word in words) {
			Helper.IsValidScrabbleWord(word);
		}
	}
}