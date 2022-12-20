namespace SharedLib.Test;

public class BoardTest
{
    private const int BoardWidth = 8;
    private const int BoardHeight = 8;
    
    [Fact]
    public void SetPlayerPosition_BottomRow_ReturnsBottomRowIndex()
    {
        const int BottomRowIndex = 7;
        
        var board = CreateBoardWithNoRules();

        Assert.Equal(BottomRowIndex, board.PlayerPosition.Row);
    }

    [Fact]
    public void SetPlayerPosition_MostLeftColumn_ReturnsFirstColumnIndex()
    {
        const int MostLeftColumnIndex = 0;
        
        var board = CreateBoardWithNoRules();

        Assert.Equal(MostLeftColumnIndex, board.PlayerPosition.Column);
    }

    [Fact]
    public void SetMines_ReturnsAnyNumberButZero()
    {
        var board = CreateBoardWithNoRules();
        
        var minesSet = board.SetMines();

        Assert.True(minesSet > 0);
    }

    [Fact]
    public void ProcessNewPlayerPosition_NoRulesSet_DoesNotThrowAnyException()
    {
        var board = CreateBoardWithNoRules();
        
        var exception = Record.Exception(() => board.OnPositionChanged(ConsoleKey.A));
        
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(ConsoleKey.U, 1)]
    [InlineData(ConsoleKey.D, -1)]
    public void ProcessPlayerNewPosition_PlayerRowPositionChangesToExpectedValue(ConsoleKey keyPressed, int rowIndexChange)
    {
        var board = CreateBoardWithNoRules();
        var playerRowIndexBeforeMove = board.PlayerPosition.Row;

        board.OnPositionChanged(keyPressed);

        var rowIndexChangedBy = playerRowIndexBeforeMove - board.PlayerPosition.Row;
        Assert.Equal(rowIndexChange, rowIndexChangedBy);
    }

    [Theory]
    [InlineData(ConsoleKey.L, 1)]
    [InlineData(ConsoleKey.R, -1)]
    public void ProcessPlayerNewPosition_PlayerColumnPositionChangesToExpectedValue(ConsoleKey keyPressed, int columnIndexChange)
    {
        var board = CreateBoardWithNoRules();
        var playerColumnIndexBeforeMove = board.PlayerPosition.Column;

        board.OnPositionChanged(keyPressed);

        var columnIndexChangedBy = playerColumnIndexBeforeMove - board.PlayerPosition.Column;
        Assert.Equal(columnIndexChange, columnIndexChangedBy);
    }

    private static Board CreateBoardWithNoRules()
    {
        WinRule noRule = null;
        return new Board(BoardWidth, BoardHeight, noRule);
    }

}