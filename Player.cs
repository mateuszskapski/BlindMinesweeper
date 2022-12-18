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
        var keepGoing = true;
        do
        {
            cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.U : 
                { 
                    keepGoing = _tracker.OnPositionChanged(Direction.Up);
                    break;
                }
                case ConsoleKey.D : 
                {
                    keepGoing = _tracker.OnPositionChanged(Direction.Down);
                    break;
                }
                case ConsoleKey.L : 
                {   
                    keepGoing = _tracker.OnPositionChanged(Direction.Left);
                    break;
                }
                case ConsoleKey.R : 
                {   
                    keepGoing = _tracker.OnPositionChanged(Direction.Right);
                    break;
                }
                default: break;
            }

        } while (cki.Key != ConsoleKey.Escape && keepGoing);
    }
}