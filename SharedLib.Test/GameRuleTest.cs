using Moq;

namespace SharedLib.Test;

public class GameRuleTest
{
    private const int BoardWidth = 8;
    private const int BoardHeight = 8;
    
    [Fact]
    public void StepOnMine_PlayerHealthDecreases()
    {
        var rule = new StepOnMineRule();
        var mockBoard = CreateMockBoard(rule, true);
        var healthBefore = mockBoard.Object.Player.Health;

        rule.KeepPlaying(mockBoard.Object);

        Assert.Equal(healthBefore - 1, mockBoard.Object.Player.Health);
    }

    [Fact]
    public void ChangePosition_StepOnSafeField_PlayerHealthStaysTheSame()
    {
        var rule = new StepOnMineRule();
        var mockBoard = CreateMockBoard(rule, false);
        var healthBefore = mockBoard.Object.Player.Health;
        
        rule.KeepPlaying(mockBoard.Object);

        Assert.Equal(healthBefore, mockBoard.Object.Player.Health);
    }

    [Fact]
    public void StepOnMine_HitThreeMines_PlayerHealthIsZero()
    {
        var rule = new StepOnMineRule().SetNext(new LoseRule());
        var mockBoard = CreateMockBoard(rule, true);

        rule.KeepPlaying(mockBoard.Object);
        rule.KeepPlaying(mockBoard.Object);
        rule.KeepPlaying(mockBoard.Object);

        Assert.Equal(0, mockBoard.Object.Player.Health);
    }

    [Fact]
    public void StepOnMine_HitThreeMines_GameEnds()
    {
        var rule = new StepOnMineRule().SetNext(new LoseRule());
        var mockBoard = CreateMockBoard(rule, true);

        rule.KeepPlaying(mockBoard.Object);
        rule.KeepPlaying(mockBoard.Object);
        var keepPlaying = rule.KeepPlaying(mockBoard.Object);

        Assert.False(keepPlaying);
    }

    private static Mock<Board> CreateMockBoard(GameRule? rule, bool includeMines)
    {
        var mockBoard = new Mock<Board>(BoardWidth, BoardHeight, rule);
        mockBoard.Setup(x => x.IsMine(It.IsAny<Position>())).Returns(includeMines);
        mockBoard.Object.CreatePlayer();

        return mockBoard;
    }

}