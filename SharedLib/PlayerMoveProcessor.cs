namespace SharedLib;

public abstract class Controller
{
    public virtual void AwaitMove()
    {
        ConsoleKeyInfo cki;
        do
        {
            Console.Write("Move: ");
            cki = Console.ReadKey();
            Console.Write(" --> ");

            OnMove(cki.Key);
            
        } while (cki.Key != ConsoleKey.Escape);
    }

    public abstract void OnMove(ConsoleKey key);
}

public class PlayerMoveController : Controller
{
    private readonly Player _player;

    public PlayerMoveController(Player player)
    {
        _player = player;
    }

    public override void OnMove(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.U: _player.Move(_player.CurrentPosition.MoveUp()); break; 
            case ConsoleKey.D: _player.Move(_player.CurrentPosition.MoveDown()); break; 
            case ConsoleKey.L: _player.Move(_player.CurrentPosition.MoveLeft()); break; 
            case ConsoleKey.R: _player.Move(_player.CurrentPosition.MoveRight()); break; 
            default: Console.WriteLine("Move not supported."); break;
        }
    }
}