namespace SharedLib.Test;

public class BoardTest
{   
    [Fact]
    public void SetPlayerPosition_BottomRow_ReturnsBottomRowIndex()
    {
        const int BottomRowIndex = 7;
        
        var board = BoardHelpers.CreateBoardWithNoRules();

        Assert.Equal(BottomRowIndex, board.Player.CurrentPosition.Row);
    }

    [Fact]
    public void SetPlayerPosition_MostLeftColumn_ReturnsFirstColumnIndex()
    {
        const int MostLeftColumnIndex = 0;
        
        var board = BoardHelpers.CreateBoardWithNoRules();

        Assert.Equal(MostLeftColumnIndex, board.Player.CurrentPosition.Column);
    }

    [Fact]
    public void SetMines_ReturnsAnyNumberButZero()
    {
        var board = BoardHelpers.CreateBoardWithNoRules();
        
        var minesSet = board.SetMines();

        Assert.True(minesSet > 0);
    }

    [Fact]
    public void ProcessNewPlayerPosition_NoRulesSet_DoesNotThrowAnyException()
    {
        var board = BoardHelpers.CreateBoardWithNoRules();
        
        var exception = Record.Exception(() => board.OnPositionChanged(new Position(0,0)));
        
        Assert.Null(exception);
    }
}