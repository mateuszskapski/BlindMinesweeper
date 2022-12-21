namespace SharedLib;
public class Board : ITracker<Position>
{
    private readonly int[,] _board;
    private readonly GameRule _rule;

    public int Width { get; }
    public int Height { get; }
    public Player Player { get; private set; }

    public Board(int width, int height, GameRule rule)
    {
        _board = new int[width, height];
        _rule = rule;
        
        Width = width;
        Height = height;
    }

    public void CreatePlayer()
    {
        Player = new Player(this);
        Player.SetInitialPosition(new Position(Height - 1, 0));
    }

    public virtual int SetMines()
    {
        var mines = 0;
        var random = new Random();
        var randomBytes = new byte[Width*Height];
        random.NextBytes(randomBytes);

        for (var row = 0; row < Width; row++)
        {
            for (var col = 0; col < Height; col++)
            {
                _board[row, col] = randomBytes[col + (row * Height)];

                if (_board[row, col] % 2 != 0)
                    mines++;
            }
        }

        if (mines == 0)
            return SetMines();

        return mines;
    }

    public void OnPositionChanged(ConsoleKey direction)
    {
        switch (direction)
        {
            case ConsoleKey.U: Player.MoveUp(); break; 
            case ConsoleKey.D: Player.MoveDown(); break; 
            case ConsoleKey.L: Player.MoveLeft(); break; 
            case ConsoleKey.R: Player.MoveRight(); break; 
            default: return;
        }

        Console.WriteLine($"Position changed! Row: {Player.CurrentPosition.Row}, Column: {Player.CurrentPosition.Column}");
        
        _rule?.KeepPlaying(this);
    }

    public virtual bool IsMine(Position position) => _board[position.Column, position.Row] % 2 != 0;

    public bool IsGameFinished => Player.Health == 0 || Player.CurrentPosition.Row == 0;
}