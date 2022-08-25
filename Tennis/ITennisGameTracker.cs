using System.Collections.Generic;

namespace Tennis;

public interface ITennisGameTracker
{
    public void RecordWin(string playerName);
    public int GetGamesWon(string playerName);
    public void ResetGamesWon();
}