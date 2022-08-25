using Xunit;

namespace Tennis.Tests;

public class PlayerTests
{
    [Fact]
    public void TestIsCalledIdentifiesPlayer()
    {
        const string nameOne = "player1";
        const string nameTwo = "player2";
        
        var playerOne = new Player { Name = nameOne };
        
        Assert.True(playerOne.IsCalled(nameOne));
        Assert.False(playerOne.IsCalled(nameTwo));
    }

    [Fact]
    public void TestIncrementPointsIncreasesUserPoints()
    {
        var player = new Player { Name = "player1" };
        
        Assert.Equal(0, player.Points);
        player.IncrementPoints();
        Assert.Equal(1, player.Points);
    }

    [Fact]
    public void TestResetPoints()
    {
        var player = new Player { Name = "player1" };
        player.IncrementPoints();
        
        Assert.Equal(1, player.Points);
        player.ResetPoints();
        Assert.Equal(0, player.Points);
    }
}