// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to the game!");

var rules = new StepOnMineRule().SetNext(new LoseRule()).SetNext(new WinRule());
var board = new Board(8, 8, rules);

var mines = board.SetMines();
Console.WriteLine($"Set {mines} mines.");

var player = new Player(board);
player.Go();