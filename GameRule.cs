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

    public virtual bool Rule(Board board)
    {
        var keepPlaying = KeepPlaying(board);
        if (_next != null)
        {
            if (keepPlaying)
                _next.Rule(board);
        }

        return keepPlaying;
    }

    protected abstract bool KeepPlaying(Board board);
}