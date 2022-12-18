public interface ITracker<T>
{
    bool OnPositionChanged(Direction direction);
}

public enum Direction
{
    Up,
    Down, 
    Left, 
    Right
}