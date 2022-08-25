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
        RecordPlayerWin(playerName);
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

    private void RecordPlayerWin(string pointWinner)
    {
        var gameHasBeenWon = ScoreCalculator.HasGameBeenWon(_playerOne.Points, _playerTwo.Points);
        if (!gameHasBeenWon)
        {
            return;
        }
        
        AddGameWinToTracker(pointWinner);
        ResetPlayerPointsAfterGame();
    }

    private void AddGameWinToTracker(string winningPlayer)
    {
        _gameTracker?.RecordWin(winningPlayer);
    }

    private void ResetPlayerPointsAfterGame()
    {
        _playerOne.ResetPoints();
        _playerTwo.ResetPoints();
    }
}
