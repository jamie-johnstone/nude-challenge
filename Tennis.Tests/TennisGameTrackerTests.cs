using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Tennis.Tests
{
    public class TrackerTestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new()
        {
            new object[] {0, 0, "Love-All"},
            new object[] {1, 1, "Fifteen-All"},
            new object[] {2, 2, "Thirty-All"},
            new object[] {3, 3, "Deuce"},
            new object[] {4, 4, "Deuce"},
            new object[] {1, 0, "Fifteen-Love"},
            new object[] {0, 1, "Love-Fifteen"},
            new object[] {2, 0, "Thirty-Love"},
            new object[] {0, 2, "Love-Thirty"},
            new object[] {3, 0, "Forty-Love"},
            new object[] {0, 3, "Love-Forty"},
            new object[] {4, 0, "Win for player1"},
            new object[] {0, 4, "Win for player2"},
            new object[] {2, 1, "Thirty-Fifteen"},
            new object[] {1, 2, "Fifteen-Thirty"},
            new object[] {3, 1, "Forty-Fifteen"},
            new object[] {1, 3, "Fifteen-Forty"},
            new object[] {4, 1, "Win for player1"},
            new object[] {1, 4, "Win for player2"},
            new object[] {3, 2, "Forty-Thirty"},
            new object[] {2, 3, "Thirty-Forty"},
            new object[] {4, 2, "Win for player1"},
            new object[] {2, 4, "Win for player2"},
            new object[] {4, 3, "Advantage player1"},
            new object[] {3, 4, "Advantage player2"},
            new object[] {5, 4, "Advantage player1"},
            new object[] {4, 5, "Advantage player2"},
            new object[] {15, 14, "Advantage player1"},
            new object[] {14, 15, "Advantage player2"},
            new object[] {6, 4, "Win for player1"},
            new object[] {4, 6, "Win for player2"},
            new object[] {16, 14, "Win for player1"},
            new object[] {14, 16, "Win for player2"},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

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
}