using System;
using Xunit;

namespace Tennis.Tests;

public class ScoreCalculatorTests
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    
    public ScoreCalculatorTests()
    {
        _playerOne = new Player { Name = "playerOne" };
        _playerTwo = new Player { Name = "playerTwo" };
    }
    
    [Fact]
    public void TestGetScoreReturnsDrawScore()
    {
        const string expectedScore = "Fifteen-All";
        SetPlayerPoints(1, 1);

        var result = ScoreCalculator.GetScore(_playerOne, _playerTwo);
        Assert.Equal(expectedScore, result);
    }
    
    [Fact]
    public void TestGetScoreReturnsNormalScore()
    {
        const string expectedScore = "Thirty-Fifteen";
        SetPlayerPoints(2, 1);

        var result = ScoreCalculator.GetScore(_playerOne, _playerTwo);
        Assert.Equal(expectedScore, result);
    }
    
    [Fact]
    public void TestGetScoreReturnsAdvantageScore()
    {
        const string expectedScore = "Advantage playerTwo";
        SetPlayerPoints(3, 4);

        var result = ScoreCalculator.GetScore(_playerOne, _playerTwo);
        Assert.Equal(expectedScore, result);
    }
    
    [Fact]
    public void TestGetScoreReturnsWinningScore()
    {
        const string expectedScore = "Win for playerTwo";
        SetPlayerPoints(3, 5);

        var result = ScoreCalculator.GetScore(_playerOne, _playerTwo);
        Assert.Equal(expectedScore, result);
    }
    
    [Fact]
    public void TestIsGameWonIdentifiesWinningScore()
    {
        var result = ScoreCalculator.HasGameBeenWon(4, 1);
        Assert.True(result);
    }

    [Fact]
    public void TestIsGameWonIdentifiesGameNotWon()
    {
        var result = ScoreCalculator.HasGameBeenWon(2, 1);
        Assert.False(result);
    }

    private void SetPlayerPoints(int playerOnePoints, int playerTwoPoints)
    {
        _playerOne.ResetPoints();
        _playerTwo.ResetPoints();
        
        var highestScore = Math.Max(playerOnePoints, playerTwoPoints);
        for (var currentPoint = 0; currentPoint < highestScore; currentPoint++)
        {
            if (currentPoint < playerOnePoints)
            {
                _playerOne.IncrementPoints();
            }

            if (currentPoint < playerTwoPoints)
            {
                _playerTwo.IncrementPoints();
            }
        }
    }
}