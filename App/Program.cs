using SharedLib;

Console.WriteLine("Welcome to the game!");

var rules = new StepOnMineRule().SetNext(new LoseRule()).SetNext(new WinRule());
var board = new Board(8, 8, rules);
board.CreatePlayer();

var mines = board.SetMines();
Console.WriteLine($"Set {mines} mines.");

var controller = new PlayerMoveController(board.Player);
controller.AwaitMove();