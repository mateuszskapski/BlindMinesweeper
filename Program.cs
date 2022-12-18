// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to the game!");

var board = new Board(8, 8);
var mines = board.SetMines();
Console.WriteLine($"Set {mines} mines.");
var player = new Player(board);
player.Go();