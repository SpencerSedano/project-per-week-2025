namespace DiceRollGame;

public static class RandomNumber
{
    public static int GetRandomNumber()
    {
        var randomNumber = Random.Shared.Next(1, 7);
        return randomNumber;
    }
}