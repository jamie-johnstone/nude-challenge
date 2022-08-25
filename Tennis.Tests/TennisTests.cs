using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace Tennis.Tests
{
    public class TestDataGenerator : IEnumerable<object[]>
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

    public class TennisTests
    {
        private const string PlayerOneName = "player1";
        private const string PlayerTwoName = "player2";
        private readonly Mock<ITennisGameTracker> _mockTennisGameTracker;

        public TennisTests()
        {
            _mockTennisGameTracker = new Mock<ITennisGameTracker>();
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis1Test(int p1, int p2, string expected)
        {
            var game = new TennisGame1(PlayerOneName, PlayerTwoName, null);
            CheckAllScores(game, p1, p2, expected);
        }

        [Fact]
        public void Tennis1UpdatesGameTrackerTest()
        {
            var mockTracker = new Mock<ITennisGameTracker>();
            var game = new TennisGame1(PlayerOneName, PlayerTwoName, mockTracker.Object);
            
            CheckAllScores(game, 4, 1, "Win for player1");
            CheckAllScores(game, 1, 4, "Win for player2");
            CheckAllScores(game, 1, 4, "Win for player2");

            mockTracker.Verify(
        tracker => tracker.RecordWin(
                It.IsAny<string>()),
                Times.Exactly(3)
            );
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis2Test(int p1, int p2, string expected)
        {
            var game = new TennisGame2(PlayerOneName, PlayerTwoName);
            CheckAllScores(game, p1, p2, expected);
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis3Test(int p1, int p2, string expected)
        {
            var game = new TennisGame3(PlayerOneName, PlayerTwoName);
            CheckAllScores(game, p1, p2, expected);
        }

        private static void CheckAllScores(ITennisGame game, int player1Score, int player2Score, string expectedScore)
        {
            var highestScore = Math.Max(player1Score, player2Score);
            for (var i = 0; i < highestScore; i++)
            {
                if (i < player1Score)
                {
                    game.WonPoint(PlayerOneName);
                }

                if (i < player2Score)
                {
                    game.WonPoint(PlayerTwoName);
                }
            }

            Assert.Equal(expectedScore, game.GetScore());
        }
    }
}