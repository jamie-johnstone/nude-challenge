using System;

namespace Tennis;

public static class ScoreCalculator
{
    private const int PointDifferenceToWin = 2;
    private const int LovePoints = 0;
    private const int FifteenPoints = 1;
    private const int ThirtyPoints = 2;
    private const int FortyPoints = 3;

    public static string GetScore(Player playerOne, Player playerTwo)
    {
        var playerOnePoints = playerOne.Points;
        var playerTwoPoints = playerTwo.Points;

        if (playerOnePoints == playerTwoPoints)
        {
            return GetDrawScore(playerOnePoints);
        }

        if (playerOnePoints <= FortyPoints && playerTwoPoints <= FortyPoints)
        {
            return GetNormalScore(playerOnePoints, playerTwoPoints);
        }

        return HasGameBeenWon(playerOnePoints, playerTwoPoints)
            ? GetWinningScore(playerOne, playerTwo)
            : GetAdvantageScore(playerOne, playerTwo);
    }

    public static bool HasGameBeenWon(int playerOnePoints, int playerTwoPoints)
    {
        var isPlayerInWinningPosition = playerOnePoints > FortyPoints || playerTwoPoints > FortyPoints;
        var scoreDifference = Math.Abs(playerOnePoints - playerTwoPoints);

        return isPlayerInWinningPosition && scoreDifference >= PointDifferenceToWin;
    }

    private static string GetDrawScore(int points)
    {
        if (points >= FortyPoints)
        {
            return "Deuce";
        }
        
        var score = GetIndividualPlayerScore(points);
        return $"{score}-All";
    }

    private static string GetWinningScore(Player playerOne, Player playerTwo)
    {
        return playerOne.Points > playerTwo.Points
            ? $"Win for {playerOne.Name}"
            : $"Win for {playerTwo.Name}";
    }

    private static string GetAdvantageScore(Player playerOne, Player playerTwo)
    {
        return playerOne.Points > playerTwo.Points
            ? $"Advantage {playerOne.Name}"
            : $"Advantage {playerTwo.Name}";
    }

    private static string GetNormalScore(int playerOnePoints, int playerTwoPoints)
    {
        var playerOneScore = GetIndividualPlayerScore(playerOnePoints);
        var playerTwoScore = GetIndividualPlayerScore(playerTwoPoints);
        return $"{playerOneScore}-{playerTwoScore}";
    }

    private static string GetIndividualPlayerScore(int playerScore)
    {
        return playerScore switch
        {
            LovePoints => "Love",
            FifteenPoints => "Fifteen",
            ThirtyPoints => "Thirty",
            _ => "Forty"
        };
    }
}