namespace Tennis;

public class TennisGame1 : ITennisGame
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    private readonly ITennisGameTracker _gameTracker;
    private string _latestScore;

    public TennisGame1(string playerOneName, string playerTwoName, ITennisGameTracker gameTracker)
    {
        _playerOne = new Player { Name = playerOneName };
        _playerTwo = new Player { Name = playerTwoName };
        _gameTracker = gameTracker;

        UpdateScoreAfterPoint(); 
    }

    public string GetScore()
    {
        return _latestScore;
    }

    public void WonPoint(string playerName)
    {
        AwardPointToPlayer(playerName);
        UpdateScoreAfterPoint();
        CheckForWin(playerName);
    }

    private void AwardPointToPlayer(string playerName)
    {
        var pointWinner = GetPlayerByName(playerName);
        pointWinner.IncrementPoints();
    }

    private Player GetPlayerByName(string playerName)
    {
        return _playerOne.IsCalled(playerName)
            ? _playerOne
            : _playerTwo;
    }

    private void UpdateScoreAfterPoint()
    {
        _latestScore = ScoreCalculator.GetScore(_playerOne, _playerTwo);
    }

    // Busy method..
    private void CheckForWin(string pointWinner)
    {
        if (!ScoreCalculator.IsGameWon(_playerOne.Points, _playerTwo.Points))
        {
            return;
        }

        _gameTracker?.RecordWin(pointWinner);
        ResetGameAfterWin();
    }

    private void ResetGameAfterWin()
    {
        _playerOne.ResetPoints();
        _playerTwo.ResetPoints();
    }
}
