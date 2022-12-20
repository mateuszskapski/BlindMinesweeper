namespace SharedLib;
public class Board : ITracker<Position>
{
    private readonly int[,] _board;
    private readonly GameRule _rule;

    public int Width { get; }
    public int Height { get; }
    public Position PlayerPosition { get; set; }
    public int RemainingLives = 3;

    public Board(int width, int height, GameRule rule)
    {
        _board = new int[width, height];
        _rule = rule;
        
        Width = width;
        Height = height;
        PlayerPosition = new Position(Height - 1, 0);
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
            case ConsoleKey.U: PlayerPosition.Row--; break; 
            case ConsoleKey.D: PlayerPosition.Row++; break; 
            case ConsoleKey.L: PlayerPosition.Column--; break; 
            case ConsoleKey.R: PlayerPosition.Column++; break; 
        }
        Console.WriteLine($"Position changed! Row: {PlayerPosition.Row}, Column: {PlayerPosition.Column}");

        _rule?.Rule(this);
    }

    public virtual bool IsMine(Position position) => _board[position.Column, position.Row] % 2 != 0;
}