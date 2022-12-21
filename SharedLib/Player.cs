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

    public void Move(Position position) => _tracker.OnPositionChanged(position);
}
