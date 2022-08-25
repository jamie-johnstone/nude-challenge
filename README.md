# Tennis Refactor Notes

## Assumptions
* Original interface ITennisGame not to be modified (not touching game 2 or 3), added additional interface for new functionality
* Existing tests were not to be modified

## Thoughts
* Default handlers for score switch expressions and invalid player names, throw or log errors
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
* Reused `Person` for TennisGameTracker, used interface so this could be changed later without affecting `TennisGame1`
