# Tennis Refactor Notes

## Assumptions
* Original interface ITennisGame not to be modified (not touching game 2 or 3), added additional interface for new functionality
* Existing tests were not to be modified
* As there is no actual "game" simulator, will add functionality to TennisGame1 that handles tracking and prove this works via tests

## Descoped
Below are refactors/changes considered but decided not necessary for initial implementation
* Default handlers for score switch expressions, throw or log errors
* Could be good to split tennis terms out to a separate class, with interface. Would allow internationalised terms etc:
```
 internal struct TennisTermsEnglish
    {
        internal const string LoveAll = "Love-All";
        internal const string FifteenAll = "Fifteen-All";
        internal const string ThirtyAll = "Thirty-All";
        internal const string Deuce = "Deuce";
        ...
```

## Other
* Defined `Player` class in same file just for clarity of exercise, I would normally have new files per class. Specific folders for types etc