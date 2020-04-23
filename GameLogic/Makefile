.PHONY: Main.cs

Spellepathy.exe: Main.cs Game.cs Player.cs Team.cs Helper.cs
	@mcs Main.cs Game.cs Player.cs Team.cs Helper.cs -out:Spellepathy.exe

Tests.exe: Tests.cs Game.cs Player.cs Team.cs Helper.cs
	@mcs Tests.cs Game.cs Player.cs Team.cs Helper.cs -out:Tests.exe

clean:
	@rm -f *.exe

tests:
	@mono Tests.exe

alltests:
	make clean && make Tests.exe && make tests

run:
	@mono Spellepathy.exe

all:
	make clean && make && make run