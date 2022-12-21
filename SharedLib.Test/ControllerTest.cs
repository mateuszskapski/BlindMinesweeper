using SharedLib;

public class ControllerTest
{
    private const int BoardWidth = 8;
    private const int BoardHeight = 8;

    [Theory]
    [InlineData(ConsoleKey.U, 1)]
    [InlineData(ConsoleKey.D, -1)]
    public void ProcessPlayerNewPosition_PlayerRowPositionChangesToExpectedValue(ConsoleKey keyPressed, int rowIndexChange)
    {
        var board = BoardHelpers.CreateBoardWithNoRules();
        var controller = new PlayerMoveController(board.Player);
        var playerRowIndexBeforeMove = board.Player.CurrentPosition.Row;
        
        controller.OnMove(keyPressed);
        var rowIndexChangedBy = playerRowIndexBeforeMove - board.Player.CurrentPosition.Row;

        Assert.Equal(rowIndexChange, rowIndexChangedBy);
    }

    [Theory]
    [InlineData(ConsoleKey.L, 1)]
    [InlineData(ConsoleKey.R, -1)]
    public void ProcessPlayerNewPosition_PlayerColumnPositionChangesToExpectedValue(ConsoleKey keyPressed, int columnIndexChange)
    {
        var board = BoardHelpers.CreateBoardWithNoRules();
        var controller = new PlayerMoveController(board.Player);
        var playerColumnIndexBeforeMove = board.Player.CurrentPosition.Column;

        controller.OnMove(keyPressed);
        var columnIndexChangedBy = playerColumnIndexBeforeMove - board.Player.CurrentPosition.Column;

        Assert.Equal(columnIndexChange, columnIndexChangedBy);
    }
}