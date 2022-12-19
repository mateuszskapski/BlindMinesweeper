public class Player
{
    private ITracker<Position> _tracker;
    
    public Player(ITracker<Position> tracker)
    {
        _tracker = tracker;
    }

    public void Go()
    {
        ConsoleKeyInfo cki;
        do
        {
            cki = Console.ReadKey();
            _tracker.OnPositionChanged(cki.Key);

        } while (cki.Key != ConsoleKey.Escape);
    }
}