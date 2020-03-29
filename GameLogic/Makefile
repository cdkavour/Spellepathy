.PHONY: Main.cs

Spellepathy.exe: Main.cs Game.cs Player.cs Team.cs
	@mcs Main.cs Game.cs Player.cs Team.cs -out:Spellepathy.exe

clean:
	@rm -f Spellepathy.exe

run:
	@mono Spellepathy.exe
