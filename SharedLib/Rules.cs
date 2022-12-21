namespace SharedLib;
public class StepOnMineRule : GameRule
{
    protected override bool ExecuteRule(Board board)
    {
        if (board.Player.Health > 0 && board.IsMine(board.Player.CurrentPosition))
        {
            board.Player.ReduceHealth();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You stepped on a mine.");
            Console.ForegroundColor = ConsoleColor.Gray;

            return true;
        }

        return true;
    }
}

public class WinRule : GameRule
{
    protected override bool ExecuteRule(Board board)
    {
        if (board.Player.CurrentPosition.Row == 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You won!");
            Console.ForegroundColor = ConsoleColor.Gray;
            return false;
        }

        return true;
    }
}

public class LoseRule : GameRule
{
    protected override bool ExecuteRule(Board board)
    {
        if (board.Player.Health == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("GameOver!");
            Console.ForegroundColor = ConsoleColor.Gray;
            return false;
        }

        return true;
    }
}
