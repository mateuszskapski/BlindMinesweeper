using SharedLib;

public static class BoardHelpers
{
    private const int BoardWidth = 8;
    private const int BoardHeight = 8;
    public static Board CreateBoardWithNoRules()
    {
        WinRule noRule = null;
        var board = new Board(BoardWidth, BoardHeight, noRule);
        board.CreatePlayer();

        return board;
    }
}