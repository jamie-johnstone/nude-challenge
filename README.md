# Tennis Refactor Notes

## Assumptions
* Original interface ITennisGame not to be modified (not touching game 2 or 3)
* Existing tests were not to be modified

## Thoughts
* Reused `Person` for TennisGameTracker as it suited this implementation. Used interface so implementation could be changed later without affecting `TennisGame1`
* Mocked out ITennisGameTracker using Moq, probably unnecessary in this context but felt like the correct thing to do when testing the game
* Default handlers switches, and invalid player names, could throw or log errors
* Could be good to split tennis terms out to a separate class that can be injected. Would allow internationalised terms etc:
```
 internal struct TennisTermsEnglish
    {
        internal const string LoveAll = "Love-All";
        internal const string FifteenAll = "Fifteen-All";
        internal const string ThirtyAll = "Thirty-All";
        internal const string Deuce = "Deuce";
        ...
```
* Instead of tracking integer points, could use some kind of enum/object for the scores and move between them