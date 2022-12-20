namespace SharedLib;
public class StepOnMineRule : GameRule
{
    protected override bool KeepPlaying(Board board)
    {
        if (board.RemainingLives > 0 && board.IsMine(board.PlayerPosition))
        {
            board.RemainingLives--;
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
    protected override bool KeepPlaying(Board board)
    {
        if (board.PlayerPosition.Row == 0)
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
    protected override bool KeepPlaying(Board board)
    {
        if (board.RemainingLives == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("GameOver!");
            Console.ForegroundColor = ConsoleColor.Gray;
            return false;
        }

        return true;
    }
}
