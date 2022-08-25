using Xunit;

namespace Tennis.Tests;

public class TennisGameTrackerTests
{
    private const string PlayerOneName = "player1";
    private const string PlayerTwoName = "player2";

    [Fact]
    public void TestRecordWinSavesCorrectlyForPlayer()
    {
        var tracker = new TennisGameTracker(PlayerOneName, PlayerTwoName);

        tracker.RecordWin(PlayerOneName);
        tracker.RecordWin(PlayerTwoName);
        tracker.RecordWin(PlayerOneName);

        var playerOneGamesWon = tracker.GetGamesWon(PlayerOneName);
        Assert.Equal(2, playerOneGamesWon);
        
        var playerTwoGamesWon = tracker.GetGamesWon(PlayerTwoName);
        Assert.Equal(1, playerTwoGamesWon);
    }
    
    [Fact]
    public void TestResetGamesClearsScores()
    {
        var tracker = new TennisGameTracker(PlayerOneName, PlayerTwoName);

        tracker.RecordWin(PlayerOneName);
        tracker.RecordWin(PlayerTwoName);

        tracker.ResetGamesWon();

        var playerOneGamesWon = tracker.GetGamesWon(PlayerOneName);
        Assert.Equal(0, playerOneGamesWon);

        var playerTwoGamesWon = tracker.GetGamesWon(PlayerTwoName);
        Assert.Equal(0, playerTwoGamesWon);
    }
}
