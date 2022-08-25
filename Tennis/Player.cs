namespace Tennis;

public class Player
{
    public string Name { get; init; }
    public int Points { get; private set; }

    public bool IsCalled(string queriedName)
    {
        return string.Equals(queriedName, Name);
    }

    public void IncrementPoints()
    {
        Points++;
    }

    public void ResetPoints()
    {
        Points = 0;
    }
}