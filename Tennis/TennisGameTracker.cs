namespace Tennis;

public class TennisGameTracker : ITennisGameTracker
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;

    public TennisGameTracker(string playerOneName, string playerTwoName)
    {
        _playerOne = new Player { Name = playerOneName };
        _playerTwo = new Player { Name = playerTwoName };
    }

    public void RecordWin(string winner)
    {
        var pointWinner = _playerOne.IsCalled(winner)
            ? _playerOne
            : _playerTwo;
            
        pointWinner.IncrementPoints();
    }

    public int GetGamesWon(string playerName)
    {
        return _playerOne.IsCalled(playerName)
            ? _playerOne.Points
            : _playerTwo.Points;
    }

    public void ResetGamesWon()
    {
        _playerOne.ResetPoints();
        _playerTwo.ResetPoints();
    }
}