namespace SharedLib;
public class Player
{
    private ITracker<Position> _tracker;
    public Position CurrentPosition { get; private set;}
    public int Health { get; private set; } = 3;
    
    public Player(ITracker<Position> tracker)
    {
        _tracker = tracker;
    }

    public void ReduceHealth() => Health--; 

    public void SetInitialPosition(Position position) => CurrentPosition = position;

    public void MoveUp() => CurrentPosition.Row--;
    public void MoveDown() => CurrentPosition.Row++;
    public void MoveLeft() => CurrentPosition.Column--;
    public void MoveRight() => CurrentPosition.Column++;

    public void Go()
    {
        ConsoleKeyInfo cki;
        do
        {
            Console.Write("Move: ");
            cki = Console.ReadKey();
            Console.Write(" --> ");
            _tracker.OnPositionChanged(cki.Key);

        } while (cki.Key != ConsoleKey.Escape && !_tracker.IsGameFinished);
    }

    
}