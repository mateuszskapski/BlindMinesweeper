namespace SharedLib;
public interface ITracker<T>
{
    void OnPositionChanged(ConsoleKey direction);
    bool IsGameFinished { get; }
}
