namespace SharedLib;
public abstract class GameRule
{
    protected GameRule? _next;

    public GameRule SetNext(GameRule nextRule)
    {
        GameRule lastRule = this;

        while (lastRule._next != null)
        {
            lastRule = lastRule._next;
        }

        lastRule._next = nextRule;
        return this;
    }

    public virtual bool KeepPlaying(Board board)
    {
        var keepPlaying = ExecuteRule(board);
        if (_next != null)
        {
            if (keepPlaying)
                keepPlaying = _next.KeepPlaying(board);
        }

        return keepPlaying;
    }

    protected abstract bool ExecuteRule(Board board);
}