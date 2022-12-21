namespace SharedLib;
public interface ITracker<T>
{
    void OnPositionChanged(Position playerNewPosition);
    bool IsGameFinished { get; }
}
