public class Board : ITracker<Position>
{
    public int Width { get; }
    public int Height { get; }
    public Position PlayerPosition { get; set; }
    private readonly int[,] _board;
    private int _lives = 3;

    public Board(int width, int height)
    {
        _board = new int[width, height];
        Width = width;
        Height = height;

        PlayerPosition = new Position(Height - 1, 0);
    }

    public int SetMines()
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

        return mines;
    }

    public bool OnPositionChanged(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up: PlayerPosition.Row--; break; 
            case Direction.Down: PlayerPosition.Row++; break; 
            case Direction.Left: PlayerPosition.Column--; break; 
            case Direction.Right: PlayerPosition.Column++; break; 
        }
        Console.WriteLine($"Position changed! Row: {PlayerPosition.Row}, Column: {PlayerPosition.Column}");

        if (IsMine(PlayerPosition))
        {
            _lives--;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You stepped on a mine.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        if (_lives == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("GameOver!");
            Console.ForegroundColor = ConsoleColor.Gray;
            return false;
        }

        if (PlayerPosition.Row == 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You won!");
            Console.ForegroundColor = ConsoleColor.Gray;
            return false;
        }

        return true;
    }

    bool IsMine(Position position) => _board[position.Column, position.Row] % 2 != 0;
}